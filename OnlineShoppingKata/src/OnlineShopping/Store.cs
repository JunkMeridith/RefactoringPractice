using System;
using System.Collections.Generic;

namespace OnlineShopping
{
    public class Store : ModelObject
    {
        private readonly Dictionary<string, Item> _itemsInStock = new Dictionary<string, Item>();
        private readonly string _name;
        private bool _droneDelivery;

        public Store(string name, bool droneDelivery) {
            _name = name;
            _droneDelivery = droneDelivery;
        }
        public void AddStockedItems(params Item[] items) {
            foreach (var item in items) {
                _itemsInStock.Add(item.Name, item);
            }
        }

        public void AddStoreEvent(StoreEvent storeEvent) {
            _itemsInStock.Add(storeEvent.Name, storeEvent);
        }

        public void RemoveStockedItems(params Item[] items) {
            foreach (var item in items) {
                _itemsInStock.Remove(item.Name);
            }
        }

        public bool HasItem(Item item) {
            return _itemsInStock.ContainsKey(item.Name);
        }

        public Item GetItem(string name) {
            return _itemsInStock[name];
        }

        public bool HasDroneDelivery() {
            return _droneDelivery;
        }

        public override string ToString() {
            return "Store{" +
                   "name='" + _name + "\', " +
                   "droneDelivery=" + _droneDelivery +
                   '}';
        }

        public void SaveToDatabase() {
            throw new InvalidOperationException("missing from this exercise - shouldn't be called from a unit test");
        }

        public void SetDroneDelivery(bool b) {
            _droneDelivery = b;
        }
    }
}