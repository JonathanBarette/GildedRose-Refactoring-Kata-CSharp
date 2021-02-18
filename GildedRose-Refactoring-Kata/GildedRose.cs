using System.Collections.Generic;
using GildedRoseRefactoringKata.Extensions;
using GildedRoseRefactoringKata.Model;

namespace GildedRoseRefactoringKata
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach(var item in Items)
            {
                item.DecreaseSellIn();
                item.UpdateQuality();
            }
        }
    }
}