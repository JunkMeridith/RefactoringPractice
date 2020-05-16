using System;

namespace OnlineShopping
{
    public class Item : ModelObject
    {
        public string Name { get; }
        public string Type { get; }
        public long Weight { get; }

        public Item(String name, String type, long weight) {
            Name = name;
            Type = type;
            Weight = weight;
        }

        public override string ToString() {
            return "Item{" +
                   "name='" + Name + '\'' +
                   ", type='" + Type + '\'' +
                   ", weight=" + Weight +
                   '}';
        }

        public void SaveToDatabase() {
            throw new InvalidOperationException("missing from this exercise - shouldn't be called from a unit test");
        }

    }
}