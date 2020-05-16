using System.IO;
using System.Text;
using FluentAssertions;
using Xunit;

namespace GildedRose.Test
{
    public class GildedRoseTests
    {
        [Fact]
        public void ValidateUpdateQuality()
        {
            var content = File.ReadAllText(Path.GetFullPath("GildedRoseUpdate30Days.txt"));
            
            content.Should().Be(UpdateQuality());
        }

        private string UpdateQuality()
        {
            var items = new[]
            {
                Item.CreateItem((string) "+5 Dexterity Vest", (int) 10, (int) 20),
                Item.CreateItem((string) "Aged Brie", (int) 2, (int) 0),
                Item.CreateItem((string) "Elixir of the Mongoose", (int) 5, (int) 7),
                Item.CreateItem((string) "Sulfuras, Hand of Ragnaros", (int) 0, (int) 80),
                Item.CreateItem((string) "Sulfuras, Hand of Ragnaros", (int) -1, (int) 80),
                Item.CreateItem((string) "Backstage passes to a TAFKAL80ETC concert", (int) 15, (int) 20),
                Item.CreateItem((string) "Backstage passes to a TAFKAL80ETC concert", (int) 10, (int) 49),
                Item.CreateItem((string) "Backstage passes to a TAFKAL80ETC concert", (int) 5, (int) 49),
                Item.CreateItem((string) "Backstage passes to a TAFKAL80ETC concert", (int) 5, (int) 48)
            };

            var app = new GildedRose(items);

            var output = new StringBuilder();
            var days = 30;
            for (var i = 0; i < days; i++)
            {
                output.AppendLine("-------- day " + i + " --------");
                output.AppendLine("name, sellIn, quality");
                foreach (var item in app.Items) {
                    output.AppendLine(item.ToString());
                }
                output.AppendLine();
                app.UpdateQuality();
            }
            return output.ToString();
        }
    }
}
