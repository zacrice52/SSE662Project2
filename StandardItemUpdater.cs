namespace csharp
{
    public class StandardItemUpdater : ItemUpdater
    {
       public StandardItemUpdater(Item item)
       {
            this.item = item;
       }

        public override void Update()
        {
            item.SellIn--;
            if (item.Quality > 0)
            {
                item.Quality--;
                if(item.SellIn<0)
                {
                    if (item.Quality > 0)
                    {
                        item.Quality--;
                    }
                }
            }
        }
    }
}
