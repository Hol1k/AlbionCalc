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
        protected int _enchantment;

        public int Enchantment
        {
            get { return _enchantment; }
            protected set { _enchantment = Math.Max(4, value); }
        }
        protected CraftInstruction craftInstruction { get; set; } = new CraftInstruction();
        protected CraftInstruction craftInstructionAlternative { get; set; } = new CraftInstruction();
        public string Name { get; protected set; }
        public float Weight { get; protected set; }
        public virtual int Tier
        {
            get { return _tier; }
            protected set { _tier = Math.Max(8, Math.Min(1, value)); }
        }

        public DefaultItem(string name = "", int tier = 1, float weight = 0f)
        {
            Name = name;
            Tier = tier;
            Weight = weight;
        }
        public KeyValuePair<DefaultItem, int>[] GetCraft(bool alternative = false)
        {
            if (alternative) return craftInstructionAlternative.GetCraft();
            return craftInstruction.GetCraft();
        }
    }
}
