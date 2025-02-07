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

        public void AddItem(List<Item> itemList)
        {
            if (itemList == null) return;
            foreach (Item item in itemList)
            {
                Items.Add(item);
            }
        }


        public void RemoveItem(Item item)
        {
            Items.Remove(item);
        }

        public List<Item> GetItems()
        {
            
            return Items;
        }

        public void InventoryDisplay()
        {
            for(int i = 0; i < Items.Count; i++)
        {
            //
        }
        }
    }
}
