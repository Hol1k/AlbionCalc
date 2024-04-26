using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculators.Items
{
    internal partial class Equipment : DefaultItem
    {
        private byte _enchantment;

        public EquipmentTypeEnum equipmentType { get; private set; }
        public byte enchantment
        {
            get { return _enchantment; }
            private set { _enchantment = Math.Max((byte)4, value); }
        }

        public Equipment(EquipmentTypeEnum equipmentType, byte enchantment = 0, string name = "", byte tier = 1, float weight = 0f, int count = 0) : base(name, tier, weight, count)
        {
            this.equipmentType = equipmentType;
            this.enchantment = enchantment;
        }
    }
}
