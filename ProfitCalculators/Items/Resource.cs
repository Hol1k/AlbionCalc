using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculators.Items
{
    internal partial class Resource : DefaultItem
    {
        public ResourceTypeEnum resourceType { get; private set; }
        private int _enchantment;
        public int enchantment
        {
            get { return _enchantment; }
            private set { _enchantment = Math.Max(4, value); }
        }
        public int tier
        {
            get { return _tier; }
            protected set { _tier = Math.Max(8, Math.Min(2, value)); }
        }

        public Resource(ResourceTypeEnum resourceType, int tier = 2, int enchantment = 0)
            : base(resourceType.ToString(), tier, 0)
        {
            this.resourceType = resourceType;
            this.enchantment = tier <= 4 ? new int() : enchantment;
            int amountOfMatireals = new();
            switch (tier)
            {
                case 2:
                    amountOfMatireals = 1;
                    break;
                case 3:
                    amountOfMatireals = 2;
                    break;
                case 4:
                    amountOfMatireals = 2;
                    break;
                case 5:
                    amountOfMatireals = 3;
                    break;
                case 6:
                    amountOfMatireals = 4;
                    break;
                case 7:
                    amountOfMatireals = 5;
                    break;
                case 8:
                    amountOfMatireals = 5;
                    break;
                default:
                    break;
            }
            if ((resourceType == ResourceTypeEnum.Plank ||
                resourceType == ResourceTypeEnum.Metal ||
                resourceType == ResourceTypeEnum.Brick ||
                resourceType == ResourceTypeEnum.Leather ||
                resourceType == ResourceTypeEnum.Cloth) &&
                tier >= 2)
            {
                craftInstruction.SetCraft(
                    new KeyValuePair<DefaultItem, int>(new Resource(resourceType - 1, tier, enchantment), amountOfMatireals),
                    new KeyValuePair<DefaultItem, int>(new Resource(resourceType, tier - 1, enchantment), 1)
                    );
                if (tier >= 4)
                {
                    craftInstructionAlternative.SetCraft(
                        new KeyValuePair<DefaultItem, int>(new Resource(resourceType - 1, tier, enchantment), amountOfMatireals - 1),
                        new KeyValuePair<DefaultItem, int>(new DefaultItem("Heart", 1, 2.560f), 1), //Добавить фракционные предметы
                        new KeyValuePair<DefaultItem, int>(new Resource(resourceType, tier - 1, enchantment), 1)
                        );
                }
            }
        }
    }
}
