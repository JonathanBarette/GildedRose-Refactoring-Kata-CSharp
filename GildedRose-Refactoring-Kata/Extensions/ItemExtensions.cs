using GildedRoseRefactoringKata.Model;

namespace GildedRoseRefactoringKata.Extensions
{
    public static class ItemExtensions
    {
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

            item.Quality = item.Quality += addingQuality;
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

            item.Quality = item.Quality -= removingQuality;
        }
    }
}