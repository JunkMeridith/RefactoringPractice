using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping
{
    public class Cart : ModelObject
    {
        public List<Item> Items { get; } = new List<Item>();
        public List<Item> UnavailableItems { get; } = new List<Item>();

        public List<Item> getItems() {
            return Items;
        }
        public void AddItem(Item item) {
            Items.Add(item);
        }
        public void AddItems(IEnumerable<Item> items) {
            Items.AddRange(items);
        }

        public void MarkAsUnavailable(Item item) {
            UnavailableItems.Add(item);
        }

        public override string ToString() {
            return "Cart{" +
                   "items=" + DisplayItems(Items) +
                   "unavailable=" + DisplayItems(UnavailableItems) +
                   '}';
        }

        private string DisplayItems(IEnumerable<Item> items) {
            var itemDisplay = new StringBuilder("\n");
            foreach (var item in items) {
                itemDisplay.Append(item);
                itemDisplay.Append("\n");
            }
            return itemDisplay.ToString();
        }

        public void SaveToDatabase() {
            throw new InvalidOperationException("missing from this exercise - shouldn't be called from a unit test");
        }

        public List<Item> GetUnavailableItems() {
            return UnavailableItems;
        }
    }
}
