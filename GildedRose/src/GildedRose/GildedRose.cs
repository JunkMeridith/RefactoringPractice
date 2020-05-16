﻿namespace GildedRose
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
            if (item.Name.Equals("Aged Brie"))
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }


                item.SellIn = item.SellIn - 1;

                if (item.SellIn < 0 && item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
            }
            else
            {
                if (item.Name.Equals("Backstage passes to a TAFKAL80ETC concert"))
                {
                    ShotGun(item);
                }
                else
                {
                    ShotGun(item);
                }
            }
        }

        private static void ShotGun(Item item)
        {
            if (!item.Name.Equals("Aged Brie")
                && !item.Name.Equals("Backstage passes to a TAFKAL80ETC concert"))
            {
                if (item.Quality > 0)
                {
                    if (!item.Name.Equals("Sulfuras, Hand of Ragnaros"))
                    {
                        item.Quality = item.Quality - 1;
                    }
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;

                    if (item.Name.Equals("Backstage passes to a TAFKAL80ETC concert"))
                    {
                        if (item.SellIn < 11)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }
                    }
                }
            }

            if (!item.Name.Equals("Sulfuras, Hand of Ragnaros"))
            {
                item.SellIn = item.SellIn - 1;
            }

            if (item.SellIn < 0)
            {
                if (!item.Name.Equals("Aged Brie"))
                {
                    if (!item.Name.Equals("Backstage passes to a TAFKAL80ETC concert"))
                    {
                        if (item.Quality > 0)
                        {
                            if (!item.Name.Equals("Sulfuras, Hand of Ragnaros"))
                            {
                                item.Quality = item.Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        item.Quality = item.Quality - item.Quality;
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
            }
        }
    }
}