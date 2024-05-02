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
        public override int tier
        {
            get { return _tier; }
            protected set { _tier = Math.Max(8, Math.Min(4, value)); }
        }

        public Artifact(string name, int tier = 4) : base(name, tier, 2) { }
    }
}
