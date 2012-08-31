using System;
using Windows.Data.Json;

namespace Transhipment
{
    public sealed class NutritionInformation
	{
        /// <summary>
        /// The number of calories
        /// </summary>
        public double Calories { get; set; }
        /// <summary>
        /// The number of grams of carbohydrates
        /// </summary>
        public double CarbohydrateContent { get; set; }
        /// <summary>
        /// 	The number of milligrams of cholesterol
        /// </summary>
        public double CholesterolContent { get; set; }
        /// <summary>
        /// The number of grams of fat
        /// </summary>
        public double FatContent { get; set; }
        /// <summary>
        /// The number of grams of fiber
        /// </summary>
        public double FiberContent { get; set; }
        /// <summary>
        /// The number of grams of protein
        /// </summary>
        public double ProteinContent { get; set; }
        /// <summary>
        /// The number of grams of saturated fat
        /// </summary>
        public double SaturatedFatContent { get; set; }
        /// <summary>
        /// The serving size, in terms of the number of volume or mass
        /// </summary>
        public string ServingSize { get; set; }
        /// <summary>
        /// The number of milligrams of sodium
        /// </summary>
        public double SodiumContent { get; set; }
        /// <summary>
        /// The number of grams of sugar
        /// </summary>
        public double SugarContent { get; set; }
        /// <summary>
        /// The number of grams of trans fat
        /// </summary>
        public double TransFatContent { get; set; }
        /// <summary>
        /// The number of grams of unsaturated fat
        /// </summary>
        public double UnsaturatedFatContent { get; set; }

		internal JsonObject ToJson()
		{
            var json = new JsonObject { { "type", JsonValue.CreateStringValue(Schema.NutritionInformation) } };
		    var properties = new JsonObject
		                         {
		                             {"calories", JsonValue.CreateNumberValue(Calories)},
		                             {"carbohydrateContent", JsonValue.CreateNumberValue(CarbohydrateContent)},
		                             {"cholesterolContent", JsonValue.CreateNumberValue(CholesterolContent)},
		                             {"fatContent", JsonValue.CreateNumberValue(FatContent)},
		                             {"fiberContent", JsonValue.CreateNumberValue(FiberContent)},
		                             {"proteinContent", JsonValue.CreateNumberValue(ProteinContent)},
		                             {"saturatedFatContent", JsonValue.CreateNumberValue(SaturatedFatContent)},
		                             {"servingSize", JsonValue.CreateStringValue(ServingSize ?? String.Empty)},
		                             {"sodiumContent", JsonValue.CreateNumberValue(SodiumContent)},
		                             {"sugarContent", JsonValue.CreateNumberValue(SugarContent)},
		                             {"transFatContent", JsonValue.CreateNumberValue(TransFatContent)},
		                             {"unsaturatedFatContent", JsonValue.CreateNumberValue(UnsaturatedFatContent)}
		                         };
            
            json.Add("properties", properties);
		    return json;
		}

        internal static NutritionInformation FromJson(JsonObject jsonObject)
		{
            IJsonValue value;
            if (!jsonObject.TryGetValue("properties", out value))
                return null;

            var properties = value.GetObject();
            if (properties == null)
                return null;

            var info = new NutritionInformation();
			if (properties.TryGetValue("calories", out value))
                info.Calories = value.GetNumber();
			if (properties.TryGetValue("carbohydrateContent", out value))
                info.CarbohydrateContent = value.GetNumber();
			if (properties.TryGetValue("cholesterolContent", out value))
                info.CholesterolContent = value.GetNumber();
			if (properties.TryGetValue("fatContent", out value))
                info.FatContent = value.GetNumber();
			if (properties.TryGetValue("fiberContent", out value))
                info.FiberContent = value.GetNumber();
			if (properties.TryGetValue("proteinContent", out value))
                info.ProteinContent = value.GetNumber();
			if (properties.TryGetValue("saturatedFatContent", out value))
                info.SaturatedFatContent = value.GetNumber();
			if (properties.TryGetValue("servingSize", out value))
                info.ServingSize = value.GetString();
			if (properties.TryGetValue("sodiumContent", out value))
                info.SodiumContent = value.GetNumber();
			if (properties.TryGetValue("sugarContent", out value))
                info.SugarContent = value.GetNumber();
			if (properties.TryGetValue("transFatContent", out value))
                info.TransFatContent = value.GetNumber();
			if (properties.TryGetValue("unsaturatedFatContent", out value))
                info.UnsaturatedFatContent = value.GetNumber();

            return info;
		}
	}
}