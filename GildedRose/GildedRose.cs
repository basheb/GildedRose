using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        private readonly IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                var updater = ItemUpdaterFactory.Create(item);
                updater.Update(item);
            }
        }
    }

    public static class ItemUpdaterFactory
    {
        public static ItemUpdater Create(Item item)
        {
            return item.Name switch
            {
                "Aged Brie" => new AgedBrieUpdater(),
                "Backstage passes to a TAFKAL80ETC concert" => new BackstagePassUpdater(),
                "Sulfuras, Hand of Ragnaros" => new SulfurasUpdater(),
                var name when name.StartsWith("Conjured") => new ConjuredItemUpdater(),
                _ => new NormalItemUpdater()
            };
        }
    }

    public abstract class ItemUpdater
    {
        public abstract void Update(Item item);
    }

    public class AgedBrieUpdater : ItemUpdater
    {
        public override void Update(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;
            }
            item.SellIn--;
            if (item.SellIn < 0 && item.Quality < 50)
            {
                item.Quality++;
            }
        }
    }

    public class BackstagePassUpdater : ItemUpdater
    {
        public override void Update(Item item)
        {
            item.SellIn--;
            if (item.SellIn < 0)
            {
                item.Quality = 0;
                return;
            }

            if (item.Quality < 50)
            {
                item.Quality++;
                if (item.SellIn < 10) item.Quality++;
                if (item.SellIn < 5) item.Quality++;
            }


            item.Quality = Math.Min(item.Quality, 50);
        }
    }

    public class SulfurasUpdater : ItemUpdater
    {
        public override void Update(Item item)
        {
            // "Sulfuras" items do not change in quality or sell-in.
        }
    }

    public class ConjuredItemUpdater : ItemUpdater
    {
        public override void Update(Item item)
        {
            item.SellIn--;
            int degradationRate = item.SellIn < 0 ? 4 : 2;
            item.Quality = Math.Max(0, item.Quality - degradationRate);
        }
    }

    public class NormalItemUpdater : ItemUpdater
    {
        public override void Update(Item item)
        {
            item.SellIn--;
            int degradationRate = item.SellIn < 0 ? 2 : 1;
            item.Quality = Math.Max(0, item.Quality - degradationRate);
        }
    }
}
