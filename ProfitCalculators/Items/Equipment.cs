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
        private short _enchantment;

        public short Enchantment
        {
            get { return _enchantment; }
            private set { _enchantment = Math.Min((short)4, value); }
        }

        public Equipment(string name, short tier = 1, short enchantment = 0)
            : base(name, tier)
        {
            Enchantment = enchantment;
        }

        protected virtual void SetCraft(string itemName)
        {
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
                if (i.Name == $"T{Tier}") { Weight = float.Parse(s: i.InnerText); break; }
            }

            item = item.FirstChild;

            int recipesCount = item.ChildNodes.Count;
            KeyValuePair<DefaultItem, int>[] recipe = new KeyValuePair<DefaultItem, int>[0];
            CraftRecipes = new CraftRecipe[recipesCount];

            for (int j = 0; j < recipesCount; j++)
            {
                XmlNode craft = item.ChildNodes[j];
                int recipeLength = craft.ChildNodes.Count;
                recipe = new KeyValuePair<DefaultItem, int>[recipeLength];
                for (int i = 0; i < recipeLength; i++)
                {
                    recipe[i] = new KeyValuePair<DefaultItem, int>(CreateItem(craft.ChildNodes[i], Tier, Enchantment),
                        Convert.ToInt32(craft.ChildNodes[i].InnerText));
                }
                CraftRecipes[j] = new CraftRecipe(recipe);
            }
        }

        protected DefaultItem CreateItem(XmlNode? item, int tier, int enchantment = 0)
        {
            string itemType = item.Attributes.GetNamedItem("itemType").InnerText;
            if (itemType == "Artifact") return new Artifact(item.Name, tier);
            if (itemType == "Resource") return new Resource(item.Name, tier, enchantment);
            return new DefaultItem (itemType, tier);
        }
    }
}
