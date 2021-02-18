using GildedRoseRefactoringKata.Model;

namespace GildedRoseRefactoringKata.Extensions
{
    public static class ItemExtensions
    {
        const int Max_Quality = 50;
        const int Min_Quality = 0;

        /// <summary>
        /// Increase the quality with.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="addingQuality">The quality to add.</param>
        public static void IncreaseQualityWith(this Item item, int addingQuality)
        {
            // Cannot increase with an adding quality that is less or equal than 0.
            if (addingQuality <= 0)
                return;

            var newQuality = item.Quality += addingQuality;
            item.Quality = newQuality <= Max_Quality ?
                           newQuality :
                           Max_Quality;
        }

        /// <summary>
        /// Decrease the quality with.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="removingQuality">The quality to remove.</param>
        public static void DecreaseQualityWith(this Item item, int removingQuality)
        {
            // Cannot decrease with an removing quality that is less or equal than 0.
            if (removingQuality <= 0)
                return;

            // "Sulfuras", being a legendary item, never decreases in Quality.
            if (item.Name == Products.Sulfuras)
                return;

            var newQuality = item.Quality -= removingQuality;
            item.Quality = newQuality >= Min_Quality ?
                           newQuality :
                           Min_Quality;
        }

        /// <summary>
        /// Decrease the sell in.
        /// </summary>
        /// <param name="item">The item.</param>
        public static void DecreaseSellIn(this Item item)
        {
            // "Sulfuras", being a legendary item, never has to be sold
            if (item.Name == Products.Sulfuras)
                return;

            item.SellIn -= 1;
        }
    }
}