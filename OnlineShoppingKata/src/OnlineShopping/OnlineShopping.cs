namespace OnlineShopping
{
    public class OnlineShopping
    {
        private readonly Session _session;

        public OnlineShopping(Session session)
        {
            _session = session;
        }
        
        public void SwitchStore(Store storeToSwitchTo)
        {
            var cart = (Cart) _session.Get("CART");
            var deliveryInformation = (DeliveryInformation) _session.Get("DELIVERY_INFO");
            var currentStore = (Store) _session.Get("STORE");
            var locationService = ((LocationService) _session.Get("LOCATION_SERVICE"));

            cart?.SetAvailability(storeToSwitchTo);
            deliveryInformation?.SetDelivery(storeToSwitchTo, locationService, currentStore, cart);

            _session.Put("STORE", storeToSwitchTo);
            _session.SaveAll();
        }

        public override string ToString()
        {
            return "OnlineShopping{\n"
                   + "session=" + _session + "\n}";
        }
    }
}