using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculators.Items
{
    internal class Shoes : Equipment
    {
        public Shoes(string name, int tier = 1, int enchantment = 0)
            : base(name, tier, enchantment)
        { SetCraft(name); }
    }
}
