using System;
using System.Collections.Generic;
using Transhipment.Helpers;
using Windows.Data.Json;

namespace Transhipment.Implementation
{
    class Recipe : CreativeWork, IRecipe
    {
        public override string Type
        {
            get { return Schema.Recipe; }
        }

        public int CookTime { get; set; }
        public string CookingMethod { get; set; }
        public IList<string> Ingredients { get; private set; }
        public NutritionInformation Nutrition { get; set; }
        public int PrepTime { get; set; }
        public IList<string> RecipeCategory { get; private set; }
        public IList<string> RecipeCuisine { get; private set; }
        public IList<string> RecipeInstructions { get; private set; }
        public string RecipeYield { get; set; }
        public int TotalTime { get; set; }

        public Recipe()
        {
            Ingredients = new List<string>();
            RecipeCategory = new List<string>();
            RecipeCuisine = new List<string>();
            RecipeInstructions = new List<string>();
        }

        internal override JsonObject ToJson(out JsonObject properties)
        {
            var json = base.ToJson(out properties);

            properties.Add("cookTime", JsonValue.CreateNumberValue(CookTime));
            properties.Add("cookingMethod", JsonValue.CreateStringValue(CookingMethod ?? String.Empty));
            properties.Add("recipeYield", JsonValue.CreateStringValue(RecipeYield ?? String.Empty));
            
            ThingHelper.AddAsObjectArray(Ingredients, "ingredients", properties, JsonValue.CreateStringValue);
            ThingHelper.AddAsObjectArray(RecipeCategory, "recipeCategory", properties, JsonValue.CreateStringValue);
            ThingHelper.AddAsObjectArray(RecipeCuisine, "recipeCuisine", properties, JsonValue.CreateStringValue);
            ThingHelper.AddAsObjectArray(RecipeInstructions, "recipeInstructions", properties, JsonValue.CreateStringValue);

            if (Nutrition != null)
                properties.Add("nutrition", Nutrition.ToJson());

            properties.Add("prepTime", JsonValue.CreateNumberValue(PrepTime));
            properties.Add("totalTime", JsonValue.CreateNumberValue(TotalTime));

            return json;
        }

        internal override JsonObject PopulateFromJson(JsonObject jsonObject)
        {
            var properties = base.PopulateFromJson(jsonObject);
            if (properties == null)
                return null;

            IJsonValue value;
            if (properties.TryGetValue("cookTime", out value))
                CookTime = (int)value.GetNumber();
            if (properties.TryGetValue("cookTime", out value))
                CookTime = (int)value.GetNumber();
            if (properties.TryGetValue("cookingMethod", out value))
                CookingMethod = value.GetString();
            if (properties.TryGetValue("prepTime", out value))
                PrepTime = (int)value.GetNumber();
            if (properties.TryGetValue("totalTime", out value))
                TotalTime = (int)value.GetNumber();

            Ingredients = ThingHelper.GetObjectArray(properties, "ingredients", x => x.GetString());
            RecipeCategory = ThingHelper.GetObjectArray(properties, "recipeCategory", x => x.GetString());
            RecipeCuisine = ThingHelper.GetObjectArray(properties, "recipeCuisine", x => x.GetString());
            RecipeInstructions = ThingHelper.GetObjectArray(properties, "recipeInstructions", x => x.GetString());

            if (properties.TryGetValue("nutrition", out value))
                Nutrition = NutritionInformation.FromJson(value.GetObject());

            return properties;
        }
    }
}