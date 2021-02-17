using System;
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
                if (Quality > 0)
                {
                    if (Name != Products.Sulfuras)
                    {
                        Quality -= 1;
                    }
                }
            }
            else
            {
                if (Quality < 50)
                {
                    Quality += 1;

                    if (Name == Products.Backstage)
                    {
                        if (SellIn < 11)
                        {
                            if (Quality < 50)
                            {
                                Quality += 1;
                            }
                        }

                        if (SellIn < 6)
                        {
                            if (Quality < 50)
                            {
                                Quality += 1;
                            }
                        }
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
                        if (Quality > 0)
                        {
                            if (Name != Products.Sulfuras)
                            {
                                Quality -= 1;
                            }
                        }
                    }
                    else
                    {
                        Quality -= Quality;
                    }
                }
                else
                {
                    if (Quality < 50)
                    {
                        Quality += 1;
                    }
                }
            }

        }
    }
}