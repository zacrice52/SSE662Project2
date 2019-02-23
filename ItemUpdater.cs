namespace csharp
{
    public abstract class ItemUpdater
    {
        protected Item item;
        public abstract void Update();

        public static ItemUpdater create(Item item)
        {
            switch(item.Name)
            {
                case "Aged Brie":
                    return new AgedBrieUpdater(item);
                case "Sulfuras, Hand of Ragnaros":
                    return new SulfurasUpdater(item);
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new BackstagePassUpdater(item);
                default:
                    return new StandardItemUpdater(item);
            }
        }
    }
}
