namespace GildedRose
{
    internal class BackstagePass : Item
    {
        protected internal BackstagePass(int sellIn, int quality) : base(
            "Backstage passes to a TAFKAL80ETC concert", sellIn,
            quality)
        {
        }

        public override void UpdateItem()
        {
            if (Quality < 50)
            {
                Quality = Quality + 1;


                if (SellIn < 11 && Quality < 50)
                {
                    Quality = Quality + 1;
                }

                if (SellIn < 6 && Quality < 50)
                {
                    Quality = Quality + 1;
                }
            }


            SellIn = SellIn - 1;

            if (SellIn < 0)
            {
                Quality = Quality - Quality;
            }
        }
    }
}