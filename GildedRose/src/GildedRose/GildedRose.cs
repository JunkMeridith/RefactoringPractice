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
                item.UpdateItem();
            }
        }
    }
}