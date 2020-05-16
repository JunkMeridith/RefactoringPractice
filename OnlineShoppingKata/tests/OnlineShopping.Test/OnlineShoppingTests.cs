using ApprovalTests.Combinations;
using ApprovalTests.Reporters;
using Xunit;

namespace OnlineShopping.Test
{
    public class OnlineShoppingTests
    {
        private readonly Store _backaplan;
        private readonly Store _nordstan;

        private readonly Item _cherryBloom;
        private readonly Item _blusherBrush;
        private readonly Item _masterclass;
        private readonly Item _makeoverNordstan;
        private Item _makeoverBackaplan;

        public OnlineShoppingTests()
        {
            _nordstan = new Store("Nordstan", false);
            _backaplan = new Store("Backaplan", true);

            _cherryBloom = new Item("Cherry Bloom", "LIPSTICK", 30);
            var rosePetal = new Item("Rose Petal", "LIPSTICK", 30);
            _blusherBrush = new Item("Blusher Brush", "TOOL", 50);
            var eyelashCurler = new Item("Eyelash curler", "TOOL", 100);
            var wildRose = new Item("Wild Rose", "PURFUME", 200);
            var cocoaButter = new Item("Cocoa Butter", "SKIN_CREAM", 250);

            _nordstan.AddStockedItems(_cherryBloom, rosePetal, _blusherBrush, eyelashCurler, wildRose, cocoaButter);
            _backaplan.AddStockedItems(_cherryBloom, rosePetal, eyelashCurler, wildRose, cocoaButter);

            // Store events add themselves to the stocked items at their store
            _masterclass = new StoreEvent("Eyeshadow Masterclass", _nordstan);
            _makeoverNordstan = new StoreEvent("Makeover", _nordstan);
            _makeoverBackaplan = new StoreEvent("Makeover", _backaplan);
        }

        [UseReporter(typeof(DiffReporter))]
        [Fact]
        public void SwitchStore()
        {
                CombinationApprovals.VerifyAllCombinations(DoSwitchStore,
                new[] {"HOME_DELIVERY", "PICKUP", "SHIPPING", null},
                new[] {"NEARBY", "NOT_NEARBY", null},
                new[] {_backaplan, null},
                new[] {true, false},
                new[] {true, false});
        }

        private object DoSwitchStore(string deliveryType, string deliveryAddress, Store storeToSwitchTo,
            bool nullCart, bool nullDeliveryInfo)
        {
            var deliveryInfo = new DeliveryInformation(deliveryType, _nordstan, 60)
            {
                DeliveryAddress = deliveryAddress
            };

            if (nullDeliveryInfo)
            {
                deliveryInfo = null;
                // if deliveryInfo is null then address is meaningless so skip this combination in the tests
                if (deliveryAddress != null)
                {
                    return null;
                }
            }

            Cart cart = new Cart();
            cart.AddItem(_cherryBloom);
            cart.AddItem(_blusherBrush);
            cart.AddItem(_masterclass);
            cart.AddItem(_makeoverNordstan);
            if (nullCart)
            {
                cart = null;
                if (deliveryInfo != null)
                {
                    return null;
                }
            }

            Session session = new NonSavingSession();
            session.Put("STORE", _nordstan);
            session.Put("DELIVERY_INFO", deliveryInfo);
            session.Put("CART", cart);
            var shopping = new OnlineShopping(session);

            shopping.SwitchStore(storeToSwitchTo);
            return shopping.ToString();
        }
    }
}