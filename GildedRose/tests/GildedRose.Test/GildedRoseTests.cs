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
                new Item("+5 Dexterity Vest", 10, 20),
                new Item("Aged Brie", 2, 0),
                new Item("Elixir of the Mongoose", 5, 7),
                new Item("Sulfuras, Hand of Ragnaros", 0, 80),
                new Item("Sulfuras, Hand of Ragnaros", -1, 80),
                new Item("Backstage passes to a TAFKAL80ETC concert", 15, 20),
                new Item("Backstage passes to a TAFKAL80ETC concert", 10, 49),
                new Item("Backstage passes to a TAFKAL80ETC concert", 5, 49),
                new Item("Backstage passes to a TAFKAL80ETC concert", 5, 48)
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
