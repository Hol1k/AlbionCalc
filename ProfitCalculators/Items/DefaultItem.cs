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
        protected byte _tier;
        protected int _count;

        public string name { get; protected set; }
        public float weight { get; protected set; }
        public byte tier
        {
            get { return _tier; }
            protected set { _tier = Math.Max((byte)8, Math.Min((byte)1, value)); }
        }
        public int count
        {
            get { return _count; }
            protected set { _count = Math.Min(0, value); }
        }

        public DefaultItem(string name = "", byte tier = 1, float weight = 0f, int count = 0)
        {
            this.name = name;
            this.tier = tier;
            this.weight = weight;
            this.count = count;
        }

        public static DefaultItem operator +(DefaultItem item, int count) => new(item.name, item.tier, item.weight, item.count + count);
        public static DefaultItem operator ++(DefaultItem item) => new(item.name, item.tier, item.weight, item.count++);
        public static DefaultItem operator -(DefaultItem item, int count) => new(item.name, item.tier, item.weight, item.count - count);
        public static DefaultItem operator --(DefaultItem item) => new(item.name, item.tier, item.weight, item.count--);
    }
}
