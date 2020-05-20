using System.Collections.Generic;

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
                    var newItems = setWeightAndAvailability(storeToSwitchTo, cart, out var weight);

                    var currentStore = (Store) _session.Get("STORE");
                    if (deliveryInformation != null
                        && deliveryInformation.Type != null
                        && "HOME_DELIVERY".Equals(deliveryInformation.Type)
                        && deliveryInformation.DeliveryAddress != null)
                    {
                        if (!((LocationService) _session.Get("LOCATION_SERVICE")).IsWithinDeliveryRange(storeToSwitchTo,
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
                        if (deliveryInformation != null
                            && deliveryInformation.DeliveryAddress != null)
                        {
                            if (((LocationService) _session.Get("LOCATION_SERVICE")).IsWithinDeliveryRange(
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

            _session.Put("STORE", storeToSwitchTo);
            _session.SaveAll();
        }

        private static List<Item> setWeightAndAvailability(Store storeToSwitchTo, Cart cart, out long weight)
        {
            var newItems = new List<Item>();
            weight = 0;
            foreach (var item in cart.getItems())
            {
                if ("EVENT".Equals(item.Type))
                {
                    if (storeToSwitchTo.HasItem(item))
                    {
                        cart.MarkAsUnavailable(item);
                        newItems.Add(storeToSwitchTo.GetItem(item.Name));
                    }
                    else
                    {
                        cart.MarkAsUnavailable(item);
                    }
                }
                else if (!storeToSwitchTo.HasItem(item))
                {
                    cart.MarkAsUnavailable(item);
                }

                weight += item.Weight;
            }

            foreach (var item in cart.GetUnavailableItems())
            {
                weight -= item.Weight;
            }
            
            foreach (var item in newItems)
            {
                cart.AddItem(item);
            }

            return newItems;
        }


        public override string ToString()
        {
            return "OnlineShopping{\n"
                   + "session=" + _session + "\n}";
        }
    }
}