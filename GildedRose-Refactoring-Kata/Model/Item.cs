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
            if (Name == Products.Backstage)
            {
                this.IncreaseQualityWith(1);

                if (SellIn < 11)
                {
                    this.IncreaseQualityWith(1);
                }

                if (SellIn < 6)
                {
                    this.IncreaseQualityWith(1);
                }
            }

            this.DecreaseSellIn();

            switch (Name)
            {
                case Products.Aged_Brie:
                    if (SellIn < 0)
                        this.IncreaseQualityWith(2);
                    else
                        this.IncreaseQualityWith(1);
                    break;
                case Products.Backstage:
                    if (SellIn < 0)
                        this.DecreaseQualityWith(Quality);
                    break;
                default:
                    if (SellIn < 0)
                        this.DecreaseQualityWith(2);
                    else
                        this.DecreaseQualityWith(1);
                    break;
            }
        }
    }
}