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

        public CraftInstruction craftInstruction { get; protected set; } = new CraftInstruction();
        public CraftInstruction craftInstructionAlternative { get; protected set; } = new CraftInstruction();
        public string name { get; protected set; }
        public float weight { get; protected set; }
        public int tier
        {
            get { return _tier; }
            protected set { _tier = Math.Max((int)8, Math.Min((int)1, value)); }
        }

        public DefaultItem(string name = "", int tier = 1, float weight = 0f)
        {
            this.name = name;
            this.tier = tier;
            this.weight = weight;
        }
    }
}
