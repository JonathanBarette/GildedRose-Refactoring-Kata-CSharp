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

        public void UpdateQuality()
        {
            this.DecreaseSellIn();

            switch (Name)
            {
                case Products.Aged_Brie:
                    this.IncreaseQualityWith(SellIn < 0 ? 2 : 1);
                    break;
                case Products.Backstage:
                    if (SellIn >= 10)
                        this.IncreaseQualityWith(1);

                    if (SellIn >= 5 && SellIn < 10)
                        this.IncreaseQualityWith(2);

                    if (SellIn >= 0 && SellIn < 5)
                        this.IncreaseQualityWith(3);

                    if (SellIn < 0)
                        this.DecreaseQualityWith(Quality);
                    break;
                default:
                    this.DecreaseQualityWith(SellIn < 0 ? 2 : 1);
                    break;
            }
        }
    }
}