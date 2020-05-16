using System;

namespace OnlineShopping
{
    public class StoreEvent : Item
    {
        private Store _location;

        public StoreEvent(String name, Store location) 
            : base(name, "EVENT", 0)
        {
            SetLocation(location);
        }

        public void SetLocation(Store locationStore) {
            _location = locationStore;
            _location.AddStoreEvent(this);
        }

        public override string ToString() {
            return "StoreEvent{" +
                   "name='" + Name + '\'' +
                   ", location=" + _location +
                   '}';
        }
    }
}