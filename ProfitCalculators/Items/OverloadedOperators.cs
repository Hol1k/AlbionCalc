using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculators.Items
{
    internal partial class DefaultItem
    {
        public static DefaultItem operator +(DefaultItem item, int count) => new(item.name, item.tier, item.weight, item.count + count);
        public static DefaultItem operator ++(DefaultItem item) => new(item.name, item.tier, item.weight, item.count++);
        public static DefaultItem operator -(DefaultItem item, int count) => new(item.name, item.tier, item.weight, item.count - count);
        public static DefaultItem operator --(DefaultItem item) => new(item.name, item.tier, item.weight, item.count--);
    }

    internal partial class Resource : DefaultItem
    {
        public static Resource operator +(Resource item, int count) => new(item.resourceType, item.enchantment, item.name, item.tier, item.weight, item.count + count);
        public static Resource operator ++(Resource item) => new(item.resourceType, item.enchantment, item.name, item.tier, item.weight, item.count++);
        public static Resource operator -(Resource item, int count) => new(item.resourceType, item.enchantment, item.name, item.tier, item.weight, item.count - count);
        public static Resource operator --(Resource item) => new(item.resourceType, item.enchantment, item.name, item.tier, item.weight, item.count--);
    }

    internal partial class Equipment : DefaultItem
    {
        public static Equipment operator +(Equipment item, int count) => new(item.equipmentType, item.enchantment, item.name, item.tier, item.weight, item.count + count);
        public static Equipment operator ++(Equipment item) => new(item.equipmentType, item.enchantment, item.name, item.tier, item.weight, item.count++);
        public static Equipment operator -(Equipment item, int count) => new(item.equipmentType, item.enchantment, item.name, item.tier, item.weight, item.count - count);
        public static Equipment operator --(Equipment item) => new(item.equipmentType, item.enchantment, item.name, item.tier, item.weight, item.count--);
    }
}
