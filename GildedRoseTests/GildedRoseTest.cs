using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{

    private Item UpdateSingleItem(string uniqueName, int sellInValue, int quality)
    {
        IList<Item> items = new List<Item> { new Item { Name = uniqueName, SellIn = sellInValue, Quality = quality } };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();

        return items[0];
    }

    [Fact]
    public void UpdateQuality_AllItems_SellInDecreases()
    {
        Item item = UpdateSingleItem("Aged Brie", 2, 0);
        Assert.Equal(1, item.SellIn);

        item = UpdateSingleItem("Backstage passes to a TAFKAL80ETC concert", 15, 20);
        Assert.Equal(14, item.SellIn);

        item = UpdateSingleItem("+5 Dexterity Vest", 10, 20);
        Assert.Equal(9, item.SellIn);

        item = UpdateSingleItem("Elixir of the Mongoose", 5, 7);
        Assert.Equal(4, item.SellIn);

        item = UpdateSingleItem("Conjured Mana Cake", 3, 6);
        Assert.Equal(2, item.SellIn);
    }

    [Fact]
    public void UpdateQuality_AllItems_QualityDoesNotDropBelowZero()
    {
        Item item = UpdateSingleItem("+5 Dexterity Vest", -1, 0);
        Assert.Equal(0, item.Quality);

        item = UpdateSingleItem("Elixir of the Mongoose", -1, 0);
        Assert.Equal(0, item.Quality);

        item = UpdateSingleItem("Conjured Mana Cake", -1, 0);
        Assert.Equal(0, item.Quality);
    }

    [Fact]
    public void UpdateQuality_AllItems_QualityDoesNotIncreaseAbove50()
    {
        // Only Aged Brie and Backstage passes can have a quality above 50
        Item item = UpdateSingleItem("Aged Brie", -1, 50);
        Assert.Equal(50, item.Quality);

        item = UpdateSingleItem("Backstage passes to a TAFKAL80ETC concert", 3, 50);
        Assert.Equal(50, item.Quality);
    }

    [Fact]
    public void UpdateQuality_Sulfuras_SellInDoesNotChange()
    {
        Item item = UpdateSingleItem("Sulfuras, Hand of Ragnaros", 0, 80);
        Assert.Equal(0, item.SellIn);
    }

    [Fact]
    public void UpdateQuality_Sulfuras_QualityDoesNotChange()
    {
        Item item = UpdateSingleItem("Sulfuras, Hand of Ragnaros", 0, 80);
        Assert.Equal(80, item.Quality);
    }

    [Fact]
    public void UpdateQuality_AllItems_QualityDropsTwiceAfterSellIn()
    {
        Item item = UpdateSingleItem("+5 Dexterity Vest", -1, 20);
        Assert.Equal(18, item.Quality);

        item = UpdateSingleItem("Elixir of the Mongoose", -1, 7);
        Assert.Equal(5, item.Quality);

        item = UpdateSingleItem("Conjured Mana Cake", -1, 6);
        Assert.Equal(2, item.Quality);
    }

    [Fact]
    public void UpdateQuality_AgedBrie_QualityIncreases()
    {
        Item item = UpdateSingleItem("Aged Brie", 2, 0);
        Assert.Equal(1, item.Quality);
    }

    [Fact]
    public void UpdateQuality_AgedBrie_QualityIncreasesTwice()
    {
        Item item = UpdateSingleItem("Aged Brie", -1, 0);
        Assert.Equal(2, item.Quality);
    }

    [Fact]
    public void UpdateQuality_BackstagePasses_QualityIncreases()
    {
        Item item = UpdateSingleItem("Backstage passes to a TAFKAL80ETC concert", 15, 20);
        Assert.Equal(21, item.Quality);
    }

    [Fact]
    public void UpdateQuality_BackstagePasses_QualityIncreasesTwice()
    {
        Item item = UpdateSingleItem("Backstage passes to a TAFKAL80ETC concert", 10, 20);
        Assert.Equal(22, item.Quality);
    }

    [Fact]
    public void UpdateQuality_BackstagePasses_QualityIncreasesThrice()
    {
        Item item = UpdateSingleItem("Backstage passes to a TAFKAL80ETC concert", 5, 20);
        Assert.Equal(23, item.Quality);
    }

    [Fact]
    public void UpdateQuality_BackstagePasses_QualityDropsToZero()
    {
        Item item = UpdateSingleItem("Backstage passes to a TAFKAL80ETC concert", 0, 20);
        Assert.Equal(0, item.Quality);
    }

    [Fact]
    public void UpdateQuality_ConjuredItem_QualityDropsTwiceAsFast()
    {
        Item item = UpdateSingleItem("Conjured Mana Cake", 3, 6);
        Assert.Equal(4, item.Quality);
    }

    [Fact]
    public void UpdateQuality_ConjuredItem_QualityDropsTwiceAsFastAfterSellIn()
    {
        Item item = UpdateSingleItem("Conjured Mana Cake", -1, 6);
        Assert.Equal(2, item.Quality);
    }

    [Fact]
    public void UpdateQuality_ConjuredItem_QualityDropsToZero()
    {
        Item item = UpdateSingleItem("Conjured Mana Cake", -1, 1);
        Assert.Equal(0, item.Quality);
    }

    [Fact]
    public void UpdateQuality_NormalItem_QualityDrops()
    {
        Item item = UpdateSingleItem("+5 Dexterity Vest", 10, 20);
        Assert.Equal(19, item.Quality);
    }

    [Fact]
    public void UpdateQuality_NormalItem_QualityDropsAfterSellIn()
    {
        Item item = UpdateSingleItem("+5 Dexterity Vest", -1, 20);
        Assert.Equal(18, item.Quality);
    }

    [Fact]
    public void UpdateQuality_NormalItem_QualityDropsToZero()
    {
        Item item = UpdateSingleItem("+5 Dexterity Vest", -1, 1);
        Assert.Equal(0, item.Quality);
    }
}