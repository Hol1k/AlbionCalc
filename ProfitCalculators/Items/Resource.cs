using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculators.Items
{
    internal class Resource : DefaultItem
    {
        public ResourceTypeEnum resourceType { get; private set; }
        private byte _enchantment;
        public byte enchantment
        {
            get { return _enchantment; }
            private set { _enchantment = Math.Max((byte)4, value); }
        }

        public Resource(ResourceTypeEnum resourceType, byte enchantment = 0, string name = "", byte tier = 1, float weight = 0f, int count = 0) : base(name, tier, weight, count)
        {
            this.resourceType = resourceType;
            this.enchantment = enchantment;
        }

        public static Resource operator +(Resource item, int count) => new(item.resourceType, item.enchantment, item.name, item.tier, item.weight, item.count + count);
        public static Resource operator ++(Resource item) => new(item.resourceType, item.enchantment, item.name, item.tier, item.weight, item.count++);
        public static Resource operator -(Resource item, int count) => new(item.resourceType, item.enchantment, item.name, item.tier, item.weight, item.count - count);
        public static Resource operator --(Resource item) => new(item.resourceType, item.enchantment, item.name, item.tier, item.weight, item.count--);
    }
}
