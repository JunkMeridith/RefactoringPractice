using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShopping
{
    public class Cart : ModelObject
    {
        private List<Item> Items { get; } = new List<Item>();
        private List<Item> UnavailableItems { get; } = new List<Item>();

        private IEnumerable<Item> GetItems()
        {
            return Items;
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        private void AddItems(IEnumerable<Item> items)
        {
            Items.AddRange(items);
        }

        private void MarkAsUnavailable(Item item)
        {
            UnavailableItems.Add(item);
        }

        public override string ToString()
        {
            return "Cart{" +
                   "items=" + DisplayItems(Items) +
                   "unavailable=" + DisplayItems(UnavailableItems) +
                   '}';
        }

        private string DisplayItems(IEnumerable<Item> items)
        {
            var itemDisplay = new StringBuilder("\n");
            foreach (var item in items)
            {
                itemDisplay.Append(item);
                itemDisplay.Append("\n");
            }

            return itemDisplay.ToString();
        }

        public void SaveToDatabase()
        {
            throw new InvalidOperationException("missing from this exercise - shouldn't be called from a unit test");
        }

        private IEnumerable<Item> GetUnavailableItems()
        {
            return UnavailableItems;
        }

        internal long SetWeight()
        {
            var weight = GetUnavailableItems().Aggregate<Item, long>(0, (current, item) => current - item.Weight);
            weight += GetItems().Sum(item => item.Weight);
            return weight;
        }

        public void SetAvailability(Store storeToSwitchTo)
        {
            var newItems = new List<Item>();
            foreach (var item in GetItems())
            {
                if (item.IsEvent())
                {
                    MarkAsUnavailable(item);
                    if (storeToSwitchTo != null && storeToSwitchTo.HasItem(item))
                    {
                        newItems.Add(storeToSwitchTo.GetItem(item.Name));
                    }
                }
                else
                {
                    if (storeToSwitchTo != null && !storeToSwitchTo.HasItem(item))
                    {
                        MarkAsUnavailable(item);
                    }
                }
            }

            AddItems(newItems);
        }
    }
}