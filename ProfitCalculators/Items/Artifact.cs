using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProfitCalculators.Items
{
    internal class Artifact : DefaultItem
    {
        public override int Tier
        {
            get { return _tier; }
            protected set { _tier = Math.Min(8, Math.Max(4, value)); }
        }

        public Artifact(string name, int tier = 4) : base(name, tier, 2) { }
    }
}
