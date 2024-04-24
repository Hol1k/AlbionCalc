using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculators.Items
{
    internal class DefaultItem
    {
        public string name { get; private set; }
        public byte tier { get; private set; }
        public float weight { get; private set; }
        public int count { get; private set; }

        public DefaultItem(string name = "", byte tier = 1, float weight = 0f, int count = 0)
        {
            this.name = name;
            this.tier = tier;
            this.weight = weight;
            this.count = count;
        }

        public static DefaultItem operator +(DefaultItem item, int count)
        {
            int newCount = item.count + count;
            item.count = newCount < 1000 ? newCount : 999;
            return item;
        }
        public static DefaultItem operator +(DefaultItem item1, DefaultItem item2)
        {
            int newCount = item1.count + item2.count;
            item1.count = newCount < 1000 ? newCount : 999;
            return item1;
        }
        public static DefaultItem operator ++(DefaultItem item)
        {
            int newCount = item.count + 1;
            item.count = newCount < 1000 ? newCount : 999;
            return item;
        }
        public static DefaultItem operator -(DefaultItem item, int count)
        {
            int newCount = item.count - count;
            item.count = newCount >= 0 ? newCount : 0;
            return item;
        }
        public static DefaultItem operator -(DefaultItem item1, DefaultItem item2)
        {
            int newCount = item1.count - item2.count;
            item1.count = newCount >= 0 ? newCount : 0;
            return item1;
        }
        public static DefaultItem operator --(DefaultItem item)
        {
            int newCount = item.count - 1;
            item.count = newCount >= 0 ? newCount : 0;
            return item;
        }
    }
}
