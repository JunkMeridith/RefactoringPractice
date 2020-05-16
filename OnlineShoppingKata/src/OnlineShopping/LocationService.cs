using System;

namespace OnlineShopping
{
    public class LocationService : ModelObject
    {
        public bool IsWithinDeliveryRange(Store store, String deliveryAddress) {
            return "NEARBY".Equals(deliveryAddress);
        }

        public override string ToString() {
            return "LocationService";
        }

        public void SaveToDatabase() {
            throw new InvalidOperationException("missing from this exercise - shouldn't be called from a unit test");
        }
    }
}