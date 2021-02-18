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
            if (Name != Products.Aged_Brie && Name != Products.Backstage)
            {
                this.DecreaseQualityWith(1);
            }
            else
            {
                this.IncreaseQualityWith(1);

                if (Name == Products.Backstage)
                {
                    if (SellIn < 11)
                    {
                        this.IncreaseQualityWith(1);
                    }

                    if (SellIn < 6)
                    {
                        this.IncreaseQualityWith(1);
                    }
                }
            }

            if (Name != Products.Sulfuras)
            {
                SellIn -= 1;
            }

            if (SellIn < 0)
            {
                if (Name != Products.Aged_Brie)
                {
                    if (Name != Products.Backstage)
                    {
                        this.DecreaseQualityWith(1);
                    }
                    else
                    {
                        this.DecreaseQualityWith(Quality);
                    }
                }
                else
                {
                    this.IncreaseQualityWith(1);
                }
            }
        }
    }
}