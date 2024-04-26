using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculators.Items
{
    internal partial class Equipment : DefaultItem
    {
        private short _enchantment;

        public EquipmentTypeEnum equipmentType { get; private set; }
        public short enchantment
        {
            get { return _enchantment; }
            private set { _enchantment = Math.Max((short)4, value); }
        }

        public Equipment(EquipmentTypeEnum equipmentType, short tier = 1, short enchantment = 0)
            : base(equipmentType.ToString(), tier, 0)
        {
            this.equipmentType = equipmentType;
            this.enchantment = enchantment;
        }
    }
}
