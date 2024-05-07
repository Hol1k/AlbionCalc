using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculators.Items
{
    internal partial class Resource : DefaultItem
    {
        public string resourceType { get; private set; }
        private int _enchantment;
        public int enchantment
        {
            get { return _enchantment; }
            private set { _enchantment = Math.Min(4, value); }
        }
        public override int tier
        {
            get { return _tier; }
            protected set { _tier = Math.Min(8, Math.Max(2, value)); }
        }

        public Resource(string resourceType, int tier = 2, int enchantment = 0)
            : base(resourceType.ToString(), tier)
        {
            this.resourceType = resourceType;
            this.enchantment = tier <= 4 ? new int() : enchantment;
            if (resourceType == "Wood" ||
                resourceType == "Stone" ||
                resourceType == "Hide" ||
                resourceType == "Ore" ||
                resourceType == "Fiber")
            {
                switch (tier)
                {
                    case 2: weight = 0.23f; return;
                    case 3: weight = 0.34f; return;
                    case 4: weight = 0.51f; return;
                    case 5: weight = 0.76f; return;
                    case 6: weight = 1.14f; return;
                    case 7: weight = 1.71f; return;
                    case 8: weight = 2.56f; return;
                }
            }
            int amountOfMatireals = new();
            KeyValuePair<DefaultItem, int>[] craft;
            switch (tier)
            {
                case 2:
                    amountOfMatireals = 1;
                    weight = 0.23f;
                    break;
                case 3:
                    amountOfMatireals = 2;
                    weight = 0.34f;
                    break;
                case 4:
                    amountOfMatireals = 2;
                    weight = 0.51f;
                    break;
                case 5:
                    amountOfMatireals = 3;
                    weight = 0.76f;
                    break;
                case 6:
                    amountOfMatireals = 4;
                    weight = 1.14f;
                    break;
                case 7:
                    amountOfMatireals = 5;
                    weight = 1.71f;
                    break;
                case 8:
                    amountOfMatireals = 5;
                    weight = 2.56f;
                    break;
                default:
                    break;
            }
            if (tier > 2)
            {
                craft = new KeyValuePair<DefaultItem, int>[2];
                craft[1] = new KeyValuePair<DefaultItem, int>(new Resource(resourceType, tier - 1, enchantment), 1);
            }
            else
            {
                craft = new KeyValuePair<DefaultItem, int>[1];
            }
            switch (resourceType)
            {
                case ("Plank"):
                    craft[0] = new KeyValuePair<DefaultItem, int>(new Resource("Wood", tier, enchantment), amountOfMatireals);
                    break;
                case ("Brick"):
                    craft[0] = new KeyValuePair<DefaultItem, int>(new Resource("Stone", tier, enchantment), amountOfMatireals);
                    break;
                case ("Leather"):
                    craft[0] = new KeyValuePair<DefaultItem, int>(new Resource("Hide", tier, enchantment), amountOfMatireals);
                    break;
                case ("Metal"):
                    craft[0] = new KeyValuePair<DefaultItem, int>(new Resource("Ore", tier, enchantment), amountOfMatireals);
                    break;
                case ("Cloth"):
                    craft[0] = new KeyValuePair<DefaultItem, int>(new Resource("Fiber", tier, enchantment), amountOfMatireals);
                    break;
                default:
                    break;
            }

            craftRecipes = new CraftRecipe[1];
            craftRecipes[0] = new CraftRecipe(craft);
        }
    }
}
