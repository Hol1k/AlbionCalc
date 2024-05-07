using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculators.Items
{
    internal partial class DefaultItem
    {
        protected int _tier;

        public CraftRecipe[] CraftRecipes { get; protected set; } = new CraftRecipe[0];
        public string Name { get; protected set; }
        public float Weight { get; protected set; }
        public virtual int Tier
        {
            get { return _tier; }
            protected set { _tier = Math.Min(8, Math.Max(1, value)); }
        }

        public DefaultItem(string name = "", int tier = 1, float weight = 0f)
        {
            Name = name;
            Tier = tier;
            Weight = weight;
        }

        public KeyValuePair<DefaultItem, int>[] GetCraft(int craftIndex)
        {
            return CraftRecipes[craftIndex].GetCraft();
        }
    }
}
