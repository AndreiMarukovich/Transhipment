using Windows.Data.Json;

namespace Transhipment
{
	public sealed class AggregateRating
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
        /// <summary>
        /// The count of total number of ratings.
        /// </summary>
        public int RatingCount { get; set; }
        /// <summary>
        /// The count of total number of reviews.
        /// </summary>
        public int ReviewCount { get; set; }

	    public AggregateRating()
	    {
	        WorstRating = 1;
	        BestRating = 5;
	    }

        public JsonObject ToJson()
        {
            var json = new JsonObject { { "type", JsonValue.CreateStringValue(Schema.AggregateRating) } };
            var properties = new JsonObject
                                 {
                                     {"bestRating", JsonValue.CreateNumberValue(BestRating)},
                                     {"ratingValue", JsonValue.CreateNumberValue(RatingValue)},
                                     {"worstRating", JsonValue.CreateNumberValue(WorstRating)},
                                     {"ratingCount", JsonValue.CreateNumberValue(RatingCount)},
                                     {"reviewCount", JsonValue.CreateNumberValue(ReviewCount)},
                                 };

            json.Add("properties", properties);

            return json;
        }

        public static AggregateRating FromJson(JsonObject jsonObject)
        {
            IJsonValue value;
            if (!jsonObject.TryGetValue("type", out value) || !value.GetString().Equals(Schema.AggregateRating))
                return null;

            var properties = value.GetObject();
            if (properties == null)
                return null;

            var rating = new AggregateRating();
            if (properties.TryGetValue("bestRating", out value))
                rating.BestRating = (int)value.GetNumber();
            if (properties.TryGetValue("ratingValue", out value))
                rating.RatingValue = (int)value.GetNumber();
            if (properties.TryGetValue("worstRating", out value))
                rating.WorstRating = (int)value.GetNumber();
            if (properties.TryGetValue("ratingCount", out value))
                rating.RatingCount = (int)value.GetNumber();
            if (properties.TryGetValue("reviewCount", out value))
                rating.ReviewCount = (int)value.GetNumber();

            return rating;
        }

	}
}