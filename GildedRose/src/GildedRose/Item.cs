namespace GildedRose
{
    public class Item
    {
        public static Item CreateItem(string name, int sellIn, int quality)
        {
            return new Item(name, sellIn, quality);
        }

        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        private Item(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public override string ToString()
        {
            return $"{Name}, {SellIn}, {Quality}";
        }
    }
}