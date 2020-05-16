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
                if (!Items[i].Name.Equals("Aged Brie")
                    && !Items[i].Name.Equals("Backstage passes to a TAFKAL80ETC concert"))
                {
                    if (Items[i].Quality > 0)
                    {
                        if (!Items[i].Name.Equals("Sulfuras, Hand of Ragnaros"))
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].Name.Equals("Backstage passes to a TAFKAL80ETC concert"))
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (!Items[i].Name.Equals("Sulfuras, Hand of Ragnaros"))
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (!Items[i].Name.Equals("Aged Brie"))
                    {
                        if (!Items[i].Name.Equals("Backstage passes to a TAFKAL80ETC concert"))
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (!Items[i].Name.Equals("Sulfuras, Hand of Ragnaros"))
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
            }
        }
    }
}