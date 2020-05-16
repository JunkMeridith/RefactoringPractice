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

        public void UpdateItem()
        {
            switch (this.Name)
            {
                case "Aged Brie":
                    if (this.Quality < 50)
                    {
                        this.Quality = this.Quality + 1;
                    }

                    this.SellIn = this.SellIn - 1;

                    if (this.SellIn < 0 && this.Quality < 50)
                    {
                        this.Quality = this.Quality + 1;
                    }

                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                {
                    if (this.Quality < 50)
                    {
                        this.Quality = this.Quality + 1;


                        if (this.SellIn < 11 && this.Quality < 50)
                        {
                            this.Quality = this.Quality + 1;
                        }

                        if (this.SellIn < 6 && this.Quality < 50)
                        {
                            this.Quality = this.Quality + 1;
                        }
                    }
                }

                    this.SellIn = this.SellIn - 1;

                    if (this.SellIn < 0)
                    {
                        this.Quality = this.Quality - this.Quality;
                    }

                    break;
                case "Sulfuras, Hand of Ragnaros": break;
                default:
                    if (this.Quality > 0)
                    {
                        this.Quality = this.Quality - 1;
                    }

                    this.SellIn = this.SellIn - 1;

                    if (this.SellIn < 0)
                    {
                        if (this.Quality > 0)
                        {
                            this.Quality = this.Quality - 1;
                        }
                    }
                    break;
            }
        }
    }
    
}