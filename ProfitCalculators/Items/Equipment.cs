using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProfitCalculators.Items
{
    abstract class Equipment : DefaultItem
    {
        private short _enchantment;

        public short enchantment
        {
            get { return _enchantment; }
            private set { _enchantment = Math.Max((short)4, value); }
        }

        public Equipment(string name, short tier = 1, short enchantment = 0)
            : base(name, tier)
        {
            this.enchantment = enchantment;
        }

        protected virtual void SetCraft(string itemName)
        {
            XmlDocument craftFile = new XmlDocument();
            craftFile.Load($".\\..\\..\\..\\Items\\EquipmentCraftInstractions\\{ToString().Split('.')[^1]}.xml");
            XmlNode? item = craftFile.DocumentElement;

            foreach (XmlNode i in item.ChildNodes)
            {
                if (i.Name == itemName)
                {
                    item = i; break;
                }
            }

            foreach (XmlNode i in item.FirstChild.ChildNodes)
            {
                if (i.Name == $"T{tier}") { weight = Convert.ToInt32(i.Value); break; }
            }

            item = item.FirstChild;

            KeyValuePair<DefaultItem, int>[] craft;
            if (item.ChildNodes.Count == 2)
            {
                craft = new KeyValuePair<DefaultItem, int>[2];
                craft[0] = new KeyValuePair<DefaultItem, int>(new Resource(item.FirstChild.Name, tier, enchantment), Convert.ToInt32(item.FirstChild.Value));
                craft[1] = new KeyValuePair<DefaultItem, int>(new Resource(item.LastChild.Name, tier, enchantment), Convert.ToInt32(item.LastChild.Value));
            }
            else
            {
                craft = new KeyValuePair<DefaultItem, int>[3];
                craft[0] = new KeyValuePair<DefaultItem, int>(new Resource(item.ChildNodes[1].Name, tier, enchantment), Convert.ToInt32(item.ChildNodes[1].Value));
                craft[1] = new KeyValuePair<DefaultItem, int>(new Resource(item.LastChild.Name, tier, enchantment), Convert.ToInt32(item.LastChild.Value));
            }

            craftInstruction = new CraftInstruction(craft);
        }
    }
}
