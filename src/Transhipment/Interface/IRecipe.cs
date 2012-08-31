using System.Collections.Generic;

namespace Transhipment
{
	public interface IRecipe : ICreativeWork
	{
        /// <summary>
        /// The time it takes to actually cook the dish, in minutes
        /// </summary>
        int CookTime { get; set; }
        /// <summary>
        /// The method of cooking, such as Frying, Steaming, ...
        /// </summary>
        string CookingMethod { get; set; }
        /// <summary>
        /// An ingredient used in the recipe.
        /// </summary>
	    IList<string> Ingredients { get; }
        /// <summary>
        /// Nutrition information about the recipe.
        /// </summary>
        NutritionInformation Nutrition { get; set; }
        /// <summary>
        /// The length of time it takes to prepare the recipe, in minutes
        /// </summary>
        int PrepTime { get; set; }
        /// <summary>
        /// The category of the recipe—for example, appetizer, entree, etc.
        /// </summary>
        IList<string> RecipeCategory { get; }
        /// <summary>
        /// The cuisine of the recipe (for example, French or Ethopian).
        /// </summary>
        IList<string> RecipeCuisine { get; }
        /// <summary>
        /// The steps to make the dish.
        /// </summary>
        IList<string> RecipeInstructions { get; }
        /// <summary>
        /// The quantity produced by the recipe (for example, number of people served, number of servings, etc).
        /// </summary>
        string RecipeYield { get; set; }
        /// <summary>
        /// The total time it takes to prepare and cook the recipe, in minutes
        /// </summary>
        int TotalTime { get; set; }
	}
}