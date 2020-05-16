namespace GildedRose
{
    public class Item
    {
        public static Item CreateItem(string name, int sellIn, int quality)
        {
            return name switch
            {
                "Aged Brie" => new AgedBrie(sellIn, quality),
                "Sulfuras, Hand of Ragnaros" => new Sulfuras(sellIn, quality),
                "Backstage passes to a TAFKAL80ETC concert" => new BackstagePass(sellIn, quality),
                _ => new Item(name, sellIn, quality)
            };
        }

        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        protected Item(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public override string ToString()
        {
            return $"{Name}, {SellIn}, {Quality}";
        }

        public virtual void UpdateItem()
        {
            if (Quality > 0)
            {
                Quality = Quality - 1;
            }

            SellIn = SellIn - 1;

            if (SellIn < 0 && Quality > 0)
            {
                Quality = Quality - 1;
            }
        }
    }
}