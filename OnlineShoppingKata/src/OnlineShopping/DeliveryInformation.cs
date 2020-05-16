using System;

namespace OnlineShopping
{
    public class DeliveryInformation : ModelObject
    {
        public string Type { get; set; }
        public string DeliveryAddress { get; set; }
        private Store _pickupLocation;
        private long _weight;

        public DeliveryInformation(String type, Store pickupLocation,
            long weight) {
            Type = type;
            _pickupLocation = pickupLocation;
            _weight = weight;
        }
        
        public void SetPickupLocation(Store store) {
            _pickupLocation = store;
        }

        public void SetTotalWeight(long weight) {
            _weight = weight;
        }

        public override string ToString() {
            return "DeliveryInformation{" + "\n" +
                   "type='" + Type + '\'' + "\n" +
                   "deliveryAddress='" + DeliveryAddress + '\'' + "\n" +
                   "pickupLocation=" + _pickupLocation + "\n" +
                   "weight=" + _weight + "\n" +
                   '}';
        }

        public void SaveToDatabase() {
            throw new InvalidOperationException("missing from this exercise - shouldn't be called from a unit test");
        }
    }
}