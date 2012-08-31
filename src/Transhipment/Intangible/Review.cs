using System;
using Transhipment.Helpers;
using Windows.Data.Json;

namespace Transhipment
{
	public sealed class Review
	{
        public string Name { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? DatePublished { get; set; }
        public IPerson Author { get; set; }
        public IThing ItemReviewed { get; set; }
        public string ReviewBody { get; set; }
        /// <summary>
        /// The ReviewRating applies to rating given by the review.
        /// </summary>
        public Rating ReviewRating { get; set; }
        /// <summary>
        /// The AggregateRating property applies to the review itself, as a creative work.
        /// </summary>
        public AggregateRating AggregateRating { get; set; }

        public JsonObject ToJson()
        {
            var json = new JsonObject { { "type", JsonValue.CreateStringValue(Schema.Review) } };
            var properties = new JsonObject
                                 {
                                     {"name", JsonValue.CreateStringValue(Name ?? String.Empty)},
                                     {"url", JsonValue.CreateStringValue(Url ?? String.Empty)},
                                     {"description", JsonValue.CreateStringValue(Description ?? String.Empty)},
                                     {"datePublished", JsonValue.CreateStringValue(DateTimeHelper.ToString(DatePublished))},
                                     {"reviewBody", JsonValue.CreateStringValue(ReviewBody ?? String.Empty)},
                                 };

            ThingHelper.AddAsObject(Author, "author", properties);
            ThingHelper.AddAsObject(ItemReviewed, "itemReviewed", properties);
            
            if (ReviewRating != null)
                properties.Add("reviewRating", ReviewRating.ToJson());
            if (AggregateRating != null)
                properties.Add("aggregateRating", AggregateRating.ToJson());

            json.Add("properties", properties);

            return json;
        }

        public static Review FromJson(JsonObject jsonObject)
        {
            IJsonValue value;
            if (!jsonObject.TryGetValue("type", out value))
                return null;

            if (!jsonObject.TryGetValue("properties", out value))
                return null;

            var properties = value.GetObject();
            if (properties == null)
                return null;

            var review = new Review();
            if (properties.TryGetValue("name", out value))
                review.Name = value.GetString();
            if (properties.TryGetValue("url", out value))
                review.Url = value.GetString();
            if (properties.TryGetValue("description", out value))
                review.Description = value.GetString();
            if (properties.TryGetValue("datePublished", out value))
                review.DatePublished = DateTimeHelper.FromString(value.GetString());
            if (properties.TryGetValue("reviewBody", out value))
                review.ReviewBody = value.GetString();

            if (properties.TryGetValue("author", out value))
                review.Author = SchemaFactory.Parse(value.GetObject()) as IPerson;
            if (properties.TryGetValue("itemReviewed", out value))
                review.ItemReviewed = SchemaFactory.Parse(value.GetObject());

            if (properties.TryGetValue("reviewRating", out value))
                review.ReviewRating = Rating.FromJson(value.GetObject());
            if (properties.TryGetValue("aggregateRating", out value))
                review.AggregateRating = AggregateRating.FromJson(value.GetObject());

            return review;
        }

	}
}