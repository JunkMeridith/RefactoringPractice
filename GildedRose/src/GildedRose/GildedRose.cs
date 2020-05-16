namespace GildedRose
{
    public class GildedRose
    {
        public Item[] Items { get; set; }

        public GildedRose(Item[] items)
        {
            Items = items;
        }

        public void UpdateQuality()
        {
            for (int i = 0; i < Items.Length; i++)
            {
                var item = Items[i];
                UpdateItem(item);
            }
        }

        private static void UpdateItem(Item item)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }

                    item.SellIn = item.SellIn - 1;

                    if (item.SellIn < 0 && item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }

                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;


                        if (item.SellIn < 11 && item.Quality < 50)
                        {
                            item.Quality = item.Quality + 1;
                        }

                        if (item.SellIn < 6 && item.Quality < 50)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }
                }

                    item.SellIn = item.SellIn - 1;

                    if (item.SellIn < 0)
                    {
                        item.Quality = item.Quality - item.Quality;
                    }

                    break;
                case "Sulfuras, Hand of Ragnaros": break;
                default:
                    if (item.Quality > 0)
                    {
                        item.Quality = item.Quality - 1;
                    }

                    item.SellIn = item.SellIn - 1;

                    if (item.SellIn < 0)
                    {
                        if (item.Quality > 0)
                        {
                            item.Quality = item.Quality - 1;
                        }
                    }
                    break;
            }
        }
    }
}