using System.Diagnostics;

namespace GildedRose
{
    public class Item
    {
        public static Item CreateItem(string name, int sellIn, int quality)
        {
            switch(name){
                case "Aged Brie":
                    return new AgedBrie(sellIn, quality);
                default:
                return new Item(name, sellIn, quality);
            }
            
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

        public void UpdateItem()
        {
            switch (Name)
            {
                case "Aged Brie":
                    if (Quality < 50)
                    {
                        Quality = Quality + 1;
                    }

                    SellIn = SellIn - 1;

                    if (SellIn < 0 && Quality < 50)
                    {
                        Quality = Quality + 1;
                    }

                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
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
                }

                    SellIn = SellIn - 1;

                    if (SellIn < 0)
                    {
                        Quality = Quality - Quality;
                    }

                    break;
                case "Sulfuras, Hand of Ragnaros": break;
                default:
                    if (Quality > 0)
                    {
                        Quality = Quality - 1;
                    }

                    SellIn = SellIn - 1;

                    if (SellIn < 0)
                    {
                        if (Quality > 0)
                        {
                            Quality = Quality - 1;
                        }
                    }
                    break;
            }
        }
    }

    class AgedBrie : Item
    {
        protected internal AgedBrie(int sellIn, int quality) : base("Aged Brie", sellIn, quality)
        {
        }
    }
}