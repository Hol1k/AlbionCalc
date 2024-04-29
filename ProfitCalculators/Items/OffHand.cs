using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProfitCalculators.Items
{
    internal class OffHand : Equipment
    {
        public OffHand(string name, short tier = 1, short enchantment = 0)
            : base(name, tier, enchantment)
        { SetCraft(name); }
    }
}
