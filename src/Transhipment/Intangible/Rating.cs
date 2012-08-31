using Windows.Data.Json;

namespace Transhipment
{
    public sealed class Rating
    {
        /// <summary>
        /// The highest value allowed in this rating system. If bestRating is omitted, 5 is assumed.
        /// </summary>
        public int BestRating { get; set; }
        /// <summary>
        /// The rating for the content.
        /// </summary>
        public int RatingValue { get; set; }
        /// <summary>
        /// The lowest value allowed in this rating system. If worstRating is omitted, 1 is assumed.
        /// </summary>
        public int WorstRating { get; set; }

        public Rating()
	    {
	        WorstRating = 1;
	        BestRating = 5;
	    }

        public JsonObject ToJson()
        {
            var json = new JsonObject { { "type", JsonValue.CreateStringValue(Schema.Rating) } };
            var properties = new JsonObject
                                 {
                                     {"bestRating", JsonValue.CreateNumberValue(BestRating)},
                                     {"ratingValue", JsonValue.CreateNumberValue(RatingValue)},
                                     {"worstRating", JsonValue.CreateNumberValue(WorstRating)},
                                 };

            json.Add("properties", properties);

            return json;
        }

        public static Rating FromJson(JsonObject jsonObject)
        {
            IJsonValue value;
            if (!jsonObject.TryGetValue("type", out value) || !value.GetString().Equals(Schema.Rating) )
                return null;

            var properties = value.GetObject();
            if (properties == null)
                return null;

            var rating = new Rating();
            if (properties.TryGetValue("bestRating", out value))
                rating.BestRating = (int)value.GetNumber();
            if (properties.TryGetValue("ratingValue", out value))
                rating.RatingValue = (int)value.GetNumber();
            if (properties.TryGetValue("worstRating", out value))
                rating.WorstRating = (int)value.GetNumber();

            return rating;
        }
    }
}