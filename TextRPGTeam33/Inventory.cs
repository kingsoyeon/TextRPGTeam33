using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPGTeam33
{
    public class Inventory
    {
        private List<Item> Items = new List<Item>();

        public void AddItem(Item item)
        {
            if (item == null) return;
            Items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            Items.Remove(item);
        }

        public List<Item> GetItems()
        {
            
            return Items;
        }
    }
}
