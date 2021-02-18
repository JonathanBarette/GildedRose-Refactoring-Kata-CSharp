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
            switch (Name)
            {
                case Products.Aged_Brie:
                    this.IncreaseQualityWith(1);
                    break;
                case Products.Backstage:
                    this.IncreaseQualityWith(1);

                    if (SellIn < 11)
                    {
                        this.IncreaseQualityWith(1);
                    }

                    if (SellIn < 6)
                    {
                        this.IncreaseQualityWith(1);
                    }
                    break;
                default:
                    this.DecreaseQualityWith(1);
                    break;
            }

            this.DecreaseSellIn();

            if (SellIn < 0)
            {
                switch (Name)
                {
                    case Products.Aged_Brie:
                        this.IncreaseQualityWith(1);
                        break;
                    case Products.Backstage:
                        this.DecreaseQualityWith(Quality);
                        break;
                    default:
                        this.DecreaseQualityWith(1);
                        break;
                }
            }

        }
    }
}