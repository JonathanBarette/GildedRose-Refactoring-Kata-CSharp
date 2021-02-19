using System;
using GildedRoseRefactoringKata.Extensions;

namespace GildedRoseRefactoringKata.Model
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public override string ToString()
        {
            return this.Name + ", " + this.SellIn + ", " + this.Quality;
        }

        /// <summary>
        /// Update the quality of an item.
        /// </summary>
        public void UpdateQuality()
        {
            switch (Name)
            {
                case Products.Aged_Brie:
                    this.IncreaseQualityWith(SellIn < 0 ? 2 : 1);
                    break;
                case Products.Backstage:
                    this.IncreaseQualityWith(SellIn >= 10 ? 1 : 0);
                    this.IncreaseQualityWith(SellIn >= 5 && SellIn < 10 ? 2 : 0);
                    this.IncreaseQualityWith(SellIn >= 0 && SellIn < 5 ? 3 : 0);
                    this.DecreaseQualityWith(SellIn < 0 ? Quality : 0);
                    break;
                case Products.Conjured:
                    this.DecreaseQualityWith(2);
                    break;
                default:
                    this.DecreaseQualityWith(SellIn < 0 ? 2 : 1);
                    break;
            }
        }
    }
}