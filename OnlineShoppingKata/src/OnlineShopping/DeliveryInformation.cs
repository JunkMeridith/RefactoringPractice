using System;

namespace OnlineShopping
{
    public class DeliveryInformation : ModelObject
    {
        private string Type { get; set; }
        public string DeliveryAddress { get; set; }
        private Store _pickupLocation;
        private long _weight;

        public DeliveryInformation(string type, Store pickupLocation,
            long weight)
        {
            Type = type;
            _pickupLocation = pickupLocation;
            _weight = weight;
        }

        private void SetPickupLocation(Store store)
        {
            _pickupLocation = store;
        }

        private void SetTotalWeight(long weight)
        {
            _weight = weight;
        }

        public override string ToString()
        {
            return "DeliveryInformation{" + "\n" +
                   "type='" + Type + '\'' + "\n" +
                   "deliveryAddress='" + DeliveryAddress + '\'' + "\n" +
                   "pickupLocation=" + _pickupLocation + "\n" +
                   "weight=" + _weight + "\n" +
                   '}';
        }

        public void SaveToDatabase()
        {
            throw new InvalidOperationException("missing from this exercise - shouldn't be called from a unit test");
        }

        private void ChangeToShipping()
        {
            Type = "SHIPPING";
            SetPickupLocation(null);
        }

        private void ChangeToPickup(Store currentStore)
        {
            Type = "PICKUP";
            SetPickupLocation(currentStore);
        }

        private void ChangeToHomeDelivery(Store storeToSwitchTo, in long weight)
        {
            Type = "HOME_DELIVERY";
            SetTotalWeight(weight);
            SetPickupLocation(storeToSwitchTo);
        }

        public void SetDelivery(Store storeToSwitchTo,
            LocationService locationService, Store currentStore, Cart cart)
        {
            if (storeToSwitchTo == null)
            {
                ChangeToShipping();
            }
            else
            {
                if (cart != null)
                {
                    var weight = cart.SetWeight();
                    var isWithinDeliveryRange = locationService.IsWithinDeliveryRange(
                        storeToSwitchTo, DeliveryAddress);
                    var hasDeliveryAddress = DeliveryAddress != null;
                    var isHomeDelivery = Type != null &&
                                         "HOME_DELIVERY".Equals(Type);

                    if (hasDeliveryAddress)
                    {
                        if (isWithinDeliveryRange)
                        {
                            ChangeToHomeDelivery(storeToSwitchTo, weight);
                        }
                        else if (isHomeDelivery)
                        {
                            ChangeToPickup(currentStore);
                        }
                    }
                }
            }
        }
    }
}