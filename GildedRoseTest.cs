using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
   
    [TestFixture]
    public class GildedRoseTest
    {
        public int sellin1 = 1;
        public int quality1 = 1;
        public string name1 = "foo";
        public int sellin2 = 2;
        public int quality2 = 2;
        public string name2 = "bar";
        public int sellin0 = 0;
        public int normalquality = 25;
        public int maxquality = 50;
        public int minquality = 0;

        [Test]
        public void SellInTest()
        {
            Item item1 = new Item { Name = name1, SellIn = sellin1, Quality = quality1 };
            Item item2 = new Item { Name = name2, SellIn = sellin2, Quality = quality2 };
            IList<Item> Items = new List<Item> { item1, item2 };
            GildedRose app = new GildedRose(Items);
            Assert.AreEqual(name1, Items[0].Name);
            Assert.AreEqual(name2, Items[1].Name);
            Assert.AreEqual(sellin1, Items[0].SellIn);
            Assert.AreEqual(sellin2, Items[1].SellIn);
            app.UpdateQuality();
            Assert.AreEqual(name1, Items[0].Name);
            Assert.AreEqual(name2, Items[1].Name);
            Assert.AreEqual(sellin1-1, Items[0].SellIn);
            Assert.AreEqual(sellin2-1, Items[1].SellIn);
        }

        [Test]
        public void QualityTest()
        {
            Item maxitem = new Item { Name = name1, SellIn = sellin1, Quality = maxquality };
            Item minitem = new Item { Name = name2, SellIn = sellin2, Quality = minquality };
            Item normalitem = new Item { Name = name2, SellIn = sellin0, Quality = normalquality };
            IList<Item> Items = new List<Item> { maxitem, minitem, normalitem };
            GildedRose app = new GildedRose(Items);
            Assert.AreEqual(name1, Items[0].Name);
            Assert.AreEqual(name2, Items[1].Name);
            Assert.AreEqual(name2, Items[2].Name);
            Assert.LessOrEqual(Items[0].Quality, maxquality);
            Assert.LessOrEqual(Items[1].Quality, maxquality);
            Assert.LessOrEqual(Items[2].Quality, maxquality);
            Assert.AreEqual(maxquality, Items[0].Quality);
            Assert.AreEqual(minquality, Items[1].Quality);
            Assert.AreEqual(normalquality, Items[2].Quality);
            app.UpdateQuality();
            Assert.AreEqual(name1, Items[0].Name);
            Assert.AreEqual(name2, Items[1].Name);
            Assert.AreEqual(name2, Items[2].Name);
            Assert.AreEqual(maxquality - 1, Items[0].Quality);
            Assert.AreEqual(minquality, Items[1].Quality);
            Assert.AreEqual(normalquality - 2, Items[2].Quality);
            Assert.GreaterOrEqual(Items[0].Quality, minquality);
            Assert.GreaterOrEqual(Items[1].Quality, minquality);
            Assert.GreaterOrEqual(Items[2].Quality, minquality);
        }
    }
}
