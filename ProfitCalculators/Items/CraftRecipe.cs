using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculators.Items
{
    internal class CraftRecipe
    {
        private DefaultItem[] craftMatireals { get; set; }
        private int[] craftMatirealCounts { get; set; }
        public int size { get; private set; }

        public CraftRecipe()
        {
            craftMatireals = new DefaultItem[0];
            craftMatirealCounts = new int[0];
            size = new();
        }

        public CraftRecipe(params KeyValuePair<DefaultItem, int>[] matireals)
        {
            size = matireals.Length;
            craftMatireals = new DefaultItem[size];
            craftMatirealCounts = new int[size];
            for (int i = 0; i < size; i++)
            {
                craftMatireals[i] = matireals[i].Key;
                craftMatirealCounts[i] = matireals[i].Value; 
            }
        }

        public void SetCraft(params KeyValuePair<DefaultItem, int>[] matireals)
        {
            size = matireals.Length;
            craftMatireals = new DefaultItem[size];
            craftMatirealCounts = new int[size];
            for (int i = 0; i < size; i++)
            {
                craftMatireals[i] = matireals[i].Key;
                craftMatirealCounts[i] = matireals[i].Value;
            }
        }

        public KeyValuePair<DefaultItem, int>[] GetCraft()
        {
            if (size == 0) return Array.Empty<KeyValuePair<DefaultItem, int>>();

            KeyValuePair<DefaultItem, int>[] craft = new KeyValuePair<DefaultItem, int>[size];

            for (int i = 0; i < size; i++)
            {
                craft[i] = new KeyValuePair<DefaultItem, int>(craftMatireals[i], craftMatirealCounts[i]);
            }

            return craft;
        }
    }
}
