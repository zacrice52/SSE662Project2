namespace csharp
{
    public class AgedBrieUpdater : ItemUpdater
    {
        public AgedBrieUpdater(Item item)
        {
            this.item = item;
        }

        public override void Update()
        {
            item.SellIn--;
            if (item.Quality < 50)
            {
                item.Quality++;
                if (item.SellIn < 0)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality++;
                    }
                }
            }
        }
    }
}
