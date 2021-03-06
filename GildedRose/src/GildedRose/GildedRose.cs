﻿namespace GildedRose
{
    public class GildedRose
    {
        public Item[] Items { get; }

        public GildedRose(Item[] items)
        {
            Items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                item.UpdateItem();
            }
        }
    }
}