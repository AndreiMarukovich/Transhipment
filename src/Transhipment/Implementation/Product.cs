using System;
using System.Collections.Generic;
using Transhipment.Helpers;
using Windows.Data.Json;

namespace Transhipment.Implementation
{
    class Product : Thing, IProduct
    {
        public override string Type
        {
            get { return Schema.Product; }
        }

        public AggregateRating AggregateRating { get; set; }
        public IOrganization Brand { get; set; }
        public IOrganization Manufacturer { get; set; }
        public string Model { get; set; }
        public string ProductId { get; set; }
        public IList<Review> Reviews { get; private set; }

        public Product()
        {
            Reviews = new List<Review>();
        }

        internal override JsonObject ToJson(out JsonObject properties)
        {
            var json = base.ToJson(out properties);

            if (AggregateRating != null)
                properties.Add("aggregateRating", AggregateRating.ToJson());

            ThingHelper.AddAsObject(Brand, "brand", properties);
            ThingHelper.AddAsObject(Manufacturer, "manufacturer", properties);
            properties.Add("model", JsonValue.CreateStringValue(Model ?? String.Empty));
            properties.Add("productId", JsonValue.CreateStringValue(ProductId ?? String.Empty));
            ThingHelper.AddAsObjectArray(Reviews, "reviews", properties, x => x.ToJson()); 

            return json;
        }

        internal override JsonObject PopulateFromJson(JsonObject jsonObject)
        {
            var properties = base.PopulateFromJson(jsonObject);
            if (properties == null)
                return null;

            IJsonValue value;
            if (properties.TryGetValue("aggregateRating", out value))
                AggregateRating = AggregateRating.FromJson(value.GetObject());

            if (properties.TryGetValue("brand", out value))
                Brand = SchemaFactory.Parse(value.GetObject()) as IOrganization;
            if (properties.TryGetValue("manufacturer", out value))
                Manufacturer = SchemaFactory.Parse(value.GetObject()) as IOrganization;

            if (properties.TryGetValue("productId", out value))
                ProductId = value.GetString();
            if (properties.TryGetValue("model", out value))
                Model = value.GetString();

            Reviews = ThingHelper.GetObjectArray(properties, "reviews", x => Review.FromJson(x.GetObject()));
            
            return properties;
        }
    }
}