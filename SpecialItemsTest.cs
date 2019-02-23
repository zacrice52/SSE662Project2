using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
   
    [TestFixture]
    public class SpecialItemsTest
    {
        public int sellin1 = 1;
        public int quality1 = 1;
        public int maxquality = 50;
        public int minquality = 0;
        public string agedbrie = "Aged Brie";
        public string sulfuras = "Sulfuras, Hand of Ragnaros";
        public string backstagepasses = "Backstage passes to a TAFKAL80ETC concert";
        public int bpquality = 25;
        public int gt10 = 11;
        public int in10 = 10;
        public int in5 = 5;
        public int today = 0;

        [Test]
        public void AgedBrieTest()
        {
            Item agedbrieitem = new Item { Name = agedbrie, SellIn = sellin1, Quality = quality1 };
            Item agedbrieitem2 = new Item { Name = agedbrie, SellIn = sellin1, Quality = maxquality };
            IList<Item> Items = new List<Item> { agedbrieitem, agedbrieitem2 };
            GildedRose app = new GildedRose(Items);
            Assert.AreEqual(agedbrie, Items[0].Name);
            Assert.AreEqual(agedbrie, Items[1].Name);
            Assert.AreEqual(quality1, Items[0].Quality);
            Assert.AreEqual(maxquality, Items[1].Quality);
            Assert.AreEqual(sellin1, Items[0].SellIn);
            Assert.AreEqual(sellin1, Items[1].SellIn);
            app.UpdateQuality();
            Assert.AreEqual(agedbrie, Items[0].Name);
            Assert.AreEqual(agedbrie, Items[1].Name);
            Assert.AreEqual(quality1 + 1, Items[0].Quality);
            Assert.AreEqual(maxquality, Items[1].Quality);
            Assert.AreEqual(sellin1 - 1, Items[0].SellIn);
            Assert.AreEqual(sellin1 - 1, Items[1].SellIn);
        }

        [Test]
        public void SulfurasTest()
        {
            Item sulfurasitem = new Item { Name = sulfuras, SellIn = sellin1, Quality = quality1 };
            IList<Item> Items = new List<Item> { sulfurasitem };
            GildedRose app = new GildedRose(Items);
            Assert.AreEqual(sulfuras, Items[0].Name);
            Assert.AreEqual(sellin1, Items[0].SellIn);
            Assert.AreEqual(quality1, Items[0].Quality);
            app.UpdateQuality();
            Assert.AreEqual(sulfuras, Items[0].Name);
            Assert.AreEqual(sellin1, Items[0].SellIn);
            Assert.AreEqual(quality1, Items[0].Quality);
        }

        [Test]
        public void BackstagePassesTest()
        {
            Item backstagepassesgt10 = new Item { Name = backstagepasses, SellIn = gt10, Quality = bpquality };
            Item backstagepasses10 = new Item { Name = backstagepasses, SellIn = in10, Quality = bpquality };
            Item backstagepasses5 = new Item { Name = backstagepasses, SellIn = in5, Quality = bpquality };
            Item backstagepasses0 = new Item { Name = backstagepasses, SellIn = today, Quality = bpquality };
            IList<Item> Items = new List<Item> { backstagepassesgt10, backstagepasses10, backstagepasses5, backstagepasses0 };
            GildedRose app = new GildedRose(Items);
            Assert.AreEqual(backstagepasses, Items[0].Name);
            Assert.AreEqual(backstagepasses, Items[1].Name);
            Assert.AreEqual(backstagepasses, Items[2].Name);
            Assert.AreEqual(backstagepasses, Items[3].Name);
            Assert.AreEqual(bpquality, Items[0].Quality);
            Assert.AreEqual(bpquality, Items[1].Quality);
            Assert.AreEqual(bpquality, Items[2].Quality);
            Assert.AreEqual(bpquality, Items[3].Quality);
            Assert.AreEqual(gt10, Items[0].SellIn);
            Assert.AreEqual(in10, Items[1].SellIn);
            Assert.AreEqual(in5, Items[2].SellIn);
            Assert.AreEqual(today, Items[3].SellIn);
            app.UpdateQuality();
            Assert.AreEqual(backstagepasses, Items[0].Name);
            Assert.AreEqual(backstagepasses, Items[1].Name);
            Assert.AreEqual(backstagepasses, Items[2].Name);
            Assert.AreEqual(backstagepasses, Items[3].Name);
            Assert.AreEqual(bpquality+1, Items[0].Quality);
            Assert.AreEqual(bpquality+2, Items[1].Quality);
            Assert.AreEqual(bpquality+3, Items[2].Quality);
            Assert.AreEqual(minquality, Items[3].Quality);
            Assert.AreEqual(gt10-1, Items[0].SellIn);
            Assert.AreEqual(in10-1, Items[1].SellIn);
            Assert.AreEqual(in5-1, Items[2].SellIn);
            Assert.AreEqual(today-1, Items[3].SellIn);
        }
    }
}
