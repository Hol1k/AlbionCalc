using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProfitCalculators.Items
{
    abstract class Equipment : DefaultItem
    {
        private int _enchantment;

        public int Enchantment
        {
            get { return _enchantment; }
            private set { _enchantment = Math.Min(4, value); }
        }

        public Equipment(string name, int tier = 1, int enchantment = 0)
            : base(name, tier)
        {
            Enchantment = enchantment;
        }

        protected virtual void SetCraft(string itemName)
        {
            //Приравнивание объекту item предмет в файле
            XmlDocument craftFile = new XmlDocument();
            craftFile.Load($".\\..\\..\\..\\Items\\EquipmentCraftInstractions\\{ToString().Split('.')[^1]}.xml");
            XmlNode? item = craftFile.DocumentElement;

            foreach (XmlNode i in item.ChildNodes)
            {
                if (i.Name == itemName)
                {
                    item = i; break;
                }
            }

            foreach (XmlNode i in item.LastChild.ChildNodes)
            {
                if (i.Name == $"T{Tier}") { Weight = float.Parse(s: i.InnerText); break; } //Установка веса
            }

            item = item.FirstChild;

            //Создание рецептов крафта
            bool isRoyalItem = item.FirstChild.Name == "RoyalSigil" ? true : false;
            int recipesCount = isRoyalItem ? item.ChildNodes.Count - 1 : item.ChildNodes.Count;

            KeyValuePair<DefaultItem, int>[] recipe = new KeyValuePair<DefaultItem, int>[0];
            CraftRecipes = new CraftRecipe[recipesCount];

            for (int j = isRoyalItem ? 1 : 0; j < (isRoyalItem ? recipesCount + 1 : recipesCount); j++)
            {
                XmlNode craft = item.ChildNodes[j];
                int recipeLength = craft.ChildNodes.Count;

                if (isRoyalItem)
                {
                    recipe = new KeyValuePair<DefaultItem, int>[recipeLength + 1];
                    recipe[^1] = new KeyValuePair<DefaultItem, int>(new Artifact(item.FirstChild.Name, Tier),
                        Convert.ToInt32(item.FirstChild.ChildNodes[Tier-4].InnerText));
                }
                else recipe = new KeyValuePair<DefaultItem, int>[recipeLength];
                for (int i = 0; i < recipeLength; i++)
                {
                    recipe[i] = new KeyValuePair<DefaultItem, int>(CreateItem(craft.ChildNodes[i], Tier, Enchantment),
                        Convert.ToInt32(craft.ChildNodes[i].InnerText));
                }
                CraftRecipes[isRoyalItem ? j-1 : j] = new CraftRecipe(recipe);
            }
        }

        protected DefaultItem CreateItem(XmlNode? item, int tier, int enchantment = 0)
        {
            string itemType = item.Attributes.GetNamedItem("itemType").InnerText;
            if (itemType == "Artifact") return new Artifact(item.Name, tier);
            if (itemType == "Resource") return new Resource(item.Name, tier, enchantment);
            if (itemType == "Head") return new Head(item.Name, tier, enchantment);
            return new DefaultItem (itemType, tier);
        }
    }
}
