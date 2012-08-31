using System;
using System.Collections.Generic;
using Transhipment.Helpers;
using Windows.Data.Json;

namespace Transhipment.Implementation
{
    class Place : Thing, IPlace
    {
        public override string Type
        {
            get { return Schema.Place; }
        }

        public IPostalAddress Address { get; set; }
        public AggregateRating AggregateRating { get; set; }
        public IPlace ContainedIn { get; set; }
        public IList<IEvent> Events { get; private set; }
        public string FaxNumber { get; set; }
        public IGeoCoordinates Geo { get; set; }
        public IList<UserInteraction> InteractionCount { get; private set; }
        public IList<string> Map { get; private set; }
        public IList<string> Photos { get; private set; }
        public IList<Review> Reviews { get; private set; }
        public string Telephone { get; set; }

        public Place()
        {
            Events = new List<IEvent>();
            InteractionCount = new List<UserInteraction>();
            Map = new List<string>();
            Photos = new List<string>();
            Reviews = new List<Review>();
        }

        internal override JsonObject ToJson(out JsonObject properties)
        {
            var json = base.ToJson(out properties);

            properties.Add("faxNumber", JsonValue.CreateStringValue(FaxNumber ?? String.Empty));
            properties.Add("telephone", JsonValue.CreateStringValue(Telephone ?? String.Empty));

            ThingHelper.AddAsObject(Address, "address", properties);
            ThingHelper.AddAsObject(ContainedIn, "containedIn", properties);
            ThingHelper.AddAsObject(Geo, "geo", properties);

            ThingHelper.AddAsObjectArray(Events, "events", properties);
            ThingHelper.AddAsObjectArray(InteractionCount, "interactionCount", properties, x=>x.ToJson());
            ThingHelper.AddAsObjectArray(Map, "map", properties, JsonValue.CreateStringValue);
            ThingHelper.AddAsObjectArray(Photos, "photos", properties, JsonValue.CreateStringValue);
            ThingHelper.AddAsObjectArray(Reviews, "reviews", properties, x => x.ToJson());

            if (AggregateRating != null)
                properties.Add("aggregateRating", AggregateRating.ToJson());

            return json;
        }

        internal override JsonObject PopulateFromJson(JsonObject jsonObject)
        {
            var properties = base.PopulateFromJson(jsonObject);
            if (properties == null)
                return null;

            IJsonValue value;
            if (properties.TryGetValue("faxNumber", out value))
                FaxNumber = value.GetString();
            if (properties.TryGetValue("telephone", out value))
                Telephone = value.GetString();

            if (properties.TryGetValue("address", out value))
                Address = SchemaFactory.Parse(value.GetObject()) as IPostalAddress;
            if (properties.TryGetValue("containedIn", out value))
                ContainedIn = SchemaFactory.Parse(value.GetObject()) as IPlace;
            if (properties.TryGetValue("geo", out value))
                Geo = SchemaFactory.Parse(value.GetObject()) as IGeoCoordinates;

            Map = ThingHelper.GetObjectArray(properties, "map", x=>x.GetString());
            Photos = ThingHelper.GetObjectArray(properties, "photos", x=>x.GetString());
            Events = ThingHelper.GetObjectArray<IEvent>(properties, "events");

            InteractionCount = ThingHelper.GetObjectArray(properties, "interactionCount", x => UserInteraction.FromJson(x.GetObject()));
            Reviews = ThingHelper.GetObjectArray(properties, "reviews", x => Review.FromJson(x.GetObject()));

            if (properties.TryGetValue("aggregateRating", out value))
                AggregateRating = AggregateRating.FromJson(value.GetObject());

            return properties;

        }
    }
}