using System.Collections.Generic;
using GildedRoseRefactoringKata;
using NUnit.Framework;

namespace GildedRoseRefactoringKataTests.GildedRoseTests
{
    /// <summary>
    /// Unit tests for UpdateQuality method in GildedRose class.
    /// </summary>
    [TestFixture]
    public class UpdateQualityTests
    {
        /// <summary>
        /// Once the sell by date has passed, Quality degrades twice as fast.
        /// </summary>
        /// <param name="sellIn">A set of values for sellIn.</param>
        /// <param name="quality">A range of quality.</param>
        [Test]
        public void GildedRose_UpdateQuality_QualityDegradesTwiceAsFast_WhenTheSellByDateHasPassed(
            [Values(0, -10, -20)] int sellIn,
            [Range(2, 50)] int quality)
        {
            //Arrange
            var items = new List<Item>
            {
                new Item { Name = "product", SellIn = sellIn, Quality = quality }
            };

            //Act
            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            //Assert
            var expectedItem = items[0];
            Assert.AreEqual(expectedItem.Quality, quality - 2);
        }

        /// <summary>
        /// The Quality of an item is never negative.
        /// </summary>
        /// <param name="sellIn">A set of values for sellIn.</param>
        /// <param name="quality">A range of quality.</param>
        [Test]
        public void GildedRose_UpdateQuality_QualityCannotBeLessThanZero(
            [Values(5, 0, -5)] int sellIn,
            [Range(0, 50)] int quality)
        {
            //Arrange
            var items = new List<Item>
            {
                new Item { Name = "product", SellIn = sellIn, Quality = quality }
            };

            //Act
            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            //Assert
            var expectedItem = items[0];
            Assert.IsTrue(expectedItem.Quality >= 0);
        }

        /// <summary>
        /// "Aged Brie" actually increases in Quality the older it gets
        /// </summary>
        /// <param name="sellIn">A range of sellIn.</param>
        [Test]
        public void GildedRose_UpdateQuality_IncreaseAgedBrieProductQuality_WhenGetsOlder(
            [Range(0, -20)] int sellIn)
        {
            //Arrange
            var quality = 20;
            var items = new List<Item>
            {
                new Item { Name = "Aged Brie", SellIn = sellIn, Quality = quality }
            };

            //Act
            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            //Assert
            var expectedItem = items[0];
            Assert.IsTrue(expectedItem.Quality > quality);
        }

        /// <summary>
        /// The Quality of an item is never more than 50. Expected "Sulfuras" that is a legendary item and as such its Quality is 80 and it never alters.
        /// </summary>
        /// <param name="productName">The product name.</param>
        [TestCase("product")]
        [TestCase("Sulfuras, Hand of Ragnaros")]
        [TestCase("Aged Brie")]
        [TestCase("Backstage passes to a TAFKAL80ETC concert")]
        public void GildedRose_UpdateQuality_QualityDoesntIncreaseMoreThan50ForAllProducts(
            string productName)
        {
            //Arrange
            var items = new List<Item>
            {
                new Item { Name = productName, SellIn = 10, Quality = 50 }
            };

            //Act
            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            //Assert
            Assert.IsTrue(items[0].Quality <= 50);
        }

        /// <summary>
        /// "Sulfuras", being a legendary item, never has to be sold or decreases in Quality.
        /// </summary>
        /// <param name="sellIn">A range of sellIn.</param>
        /// <param name="quality">A set of values for quality.</param>
        [Test]
        public void GildedRose_UpdateQuality_SufurasProductNeverHasToBeSoldOrDecreasesInQuality(
            [Range(-5, 5)] int sellIn,
            [Values(10, 25, 50)] int quality)
        {
            //Arrange
            var items = new List<Item>
            {
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = sellIn, Quality = quality }
            };

            //Act
            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            //Assert
            var expectedItem = items[0];
            Assert.AreEqual(expectedItem.SellIn, sellIn);
            Assert.AreEqual(expectedItem.Quality, quality);
        }

        /// <summary>
        /// "Backstage passes" quality increases by 1 when there are more than 10 days.
        /// </summary>
        /// <param name="sellIn">The range of sellIn.</param>
        [Test]
        public void GildedRose_UpdateQuality_IncreaseBackstagePassesProductQualityBy1_WhenSellInIsMoreThan10Days(
            [Range(11, 20)] int sellIn)
        {
            //Arrange
            var quality = 0;
            var items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality }
            };

            //Act
            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            //Assert
            var expectedItem = items[0];
            Assert.AreEqual(expectedItem.Quality, quality + 1);
        }

        /// <summary>
        /// "Backstage passes" quality increases by 2 when there are 10 days or less.
        /// </summary>
        /// <param name="sellIn">The range of sellIn.</param>
        public void GildedRose_UpdateQuality_IncreaseBackstagePassesProductQualityBy2_WhenSellInIsBetween10And6Days(
            [Range(6, 10)] int sellIn)
        {
            //Arrange
            var quality = 0;
            var items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality }
            };

            //Act
            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            //Assert
            var expectedItem = items[0];
            Assert.AreEqual(expectedItem.Quality, quality + 2);
        }

        /// <summary>
        /// "Backstage passes" quality increases by 3 when there are 5 days or less.
        /// </summary>
        /// <param name="sellIn">The range of sellIn.</param>
        [Test]
        public void GildedRose_UpdateQuality_IncreaseBackstagePassesProductQualityBy3_WhenSellInIsBetween5And1Day(
            [Range(1, 5)] int sellIn)
        {
            //Arrange
            var quality = 0;
            var items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality }
            };

            //Act
            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            //Assert
            var expectedItem = items[0];
            Assert.AreEqual(expectedItem.Quality, quality + 3);
        }

        /// <summary>
        /// "Backstage passes" quality drops to 0 after the concert.
        /// </summary>
        /// <param name="sellIn">A set of values for sellIn.</param>
        /// <param name="quality">The range of quality.</param>
        [Test]
        public void GildedRose_UpdateQuality_BackstagePassesProductQualityDropsTo0_WhenConcertIsOver(
            [Values(0, -5, -10)] int sellIn,
            [Range(0, 50)] int quality)
        {
            //Arrange
            var items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality }
            };

            //Act
            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            //Assert
            var expectedItem = items[0];
            Assert.AreEqual(expectedItem.Quality, 0);
        }
    }
}