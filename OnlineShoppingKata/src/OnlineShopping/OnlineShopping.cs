using System.Collections.Generic;
using System.Linq;

namespace OnlineShopping
{
    public class OnlineShopping
    {
        private readonly Session _session;

        public OnlineShopping(Session session)
        {
            _session = session;
        }

        /**
         * This method is called when the user changes the
         * store they are shopping at in the online shopping
         * website.
         *
         */
        public void SwitchStore(Store storeToSwitchTo)
        {
            var cart = (Cart) _session.Get("CART");
            var deliveryInformation = (DeliveryInformation) _session.Get("DELIVERY_INFO");
            if (storeToSwitchTo == null)
            {
                if (cart != null)
                {
                    foreach (var item in cart.getItems())
                    {
                        if ("EVENT".Equals(item.Type))
                        {
                            cart.MarkAsUnavailable(item);
                        }
                    }
                }

                if (deliveryInformation != null)
                {
                    deliveryInformation.Type = "SHIPPING";
                    deliveryInformation.SetPickupLocation(null);
                }
            }
            else
            {
                if (cart != null)
                {
                    SetAvailability(storeToSwitchTo, cart);
                    var weight = SetWeight(cart);
                    SetDelivery(storeToSwitchTo, deliveryInformation, weight);
                }
            }

            _session.Put("STORE", storeToSwitchTo);
            _session.SaveAll();
        }

        private void SetDelivery(Store storeToSwitchTo, DeliveryInformation deliveryInformation, long weight)
        {
            var currentStore = (Store) _session.Get("STORE");
            var locationService = (LocationService) _session.Get("LOCATION_SERVICE");
            if (deliveryInformation?.Type != null)
            {
                if ("HOME_DELIVERY".Equals(deliveryInformation.Type)
                    && deliveryInformation.DeliveryAddress != null)
                {
                    if (!locationService.IsWithinDeliveryRange(storeToSwitchTo,
                        deliveryInformation.DeliveryAddress))
                    {
                        deliveryInformation.Type = "PICKUP";
                        deliveryInformation.SetPickupLocation(currentStore);
                    }
                    else
                    {
                        deliveryInformation.SetTotalWeight(weight);
                        deliveryInformation.SetPickupLocation(storeToSwitchTo);
                    }
                }
                else
                {
                    if (deliveryInformation.DeliveryAddress != null)
                    {
                        if (locationService.IsWithinDeliveryRange(
                            storeToSwitchTo, deliveryInformation.DeliveryAddress))
                        {
                            deliveryInformation.Type = "HOME_DELIVERY";
                            deliveryInformation.SetTotalWeight(weight);
                            deliveryInformation.SetPickupLocation(storeToSwitchTo);
                        }
                    }
                }
            }
        }

        private static void SetAvailability(Store storeToSwitchTo, Cart cart)
        {
            var newItems = new List<Item>();
            foreach (var item in cart.getItems())
            {
                if ("EVENT".Equals(item.Type) && storeToSwitchTo.HasItem(item))
                {
                    cart.MarkAsUnavailable(item);
                    newItems.Add(storeToSwitchTo.GetItem(item.Name));
                }
                else if (!storeToSwitchTo.HasItem(item))
                {
                    cart.MarkAsUnavailable(item);
                }
            }

            foreach (var item in newItems)
            {
                cart.AddItem(item);
            }
        }

        private static long SetWeight(Cart cart)
        {
            long weight = cart.getItems().Sum(x => x.Weight);
            weight = cart.GetUnavailableItems().Aggregate(weight, (current, item) => current - item.Weight);
            return weight;
        }


        public override string ToString()
        {
            return "OnlineShopping{\n"
                   + "session=" + _session + "\n}";
        }
    }
}