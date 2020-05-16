namespace GildedRose
{
    class AgedBrie : Item
    {
        protected internal AgedBrie(int sellIn, int quality) : base("Aged Brie", sellIn, quality)
        {
        }

        public override void UpdateItem()
        {
            if (Quality < 50)
            {
                Quality += 1;
            }

            SellIn -= 1;

            if (SellIn < 0 && Quality < 50)
            {
                Quality += 1;
            }
        }
    }
}