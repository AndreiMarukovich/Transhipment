using System;
using System.Collections.Generic;
using Transhipment.Helpers;
using Windows.Data.Json;

namespace Transhipment.Implementation
{
    class Organization : Thing, IOrganization
    {
        public override string Type
        {
            get { return Schema.Organization; }
        }

        public IList<IPostalAddress> Address { get; private set; }
        public AggregateRating AggregateRating { get; set; }
        public IList<IContactPoint> ContactPoints { get; private set; }
        public string Email { get; set; }
        public IList<IPerson> Employees { get; private set; }
        public IList<IEvent> Events { get; private set; }
        public string FaxNumber { get; set; }
        public IList<IPerson> Founders { get; private set; }
        public DateTimeOffset? FoundingDate { get; set; }
        public IList<UserInteraction> InteractionCount { get; private set; }
        public IList<IPlace> Location { get; private set; }
        public IList<IOrganization> Members { get; private set; }
        public IList<Review> Reviews { get; private set; }
        public string Telephone { get; set; }

        public Organization()
        {
            Address = new List<IPostalAddress>();
            ContactPoints = new List<IContactPoint>();
            Employees = new List<IPerson>();
            Events = new List<IEvent>();
            Founders = new List<IPerson>();
            InteractionCount = new List<UserInteraction>();
            Location = new List<IPlace>();
            Members = new List<IOrganization>();
            Reviews = new List<Review>();
        }

        internal override JsonObject ToJson(out JsonObject properties)
        {
            var json = base.ToJson(out properties);

            properties.Add("email", JsonValue.CreateStringValue(Email ?? String.Empty));
            properties.Add("faxNumber", JsonValue.CreateStringValue(FaxNumber ?? String.Empty));
            properties.Add("telephone", JsonValue.CreateStringValue(Telephone ?? String.Empty));
            properties.Add("foundingDate", JsonValue.CreateStringValue(DateTimeHelper.ToString(FoundingDate)));

            ThingHelper.AddAsObjectArray(Address, "address", properties);
            ThingHelper.AddAsObjectArray(ContactPoints, "contactPoints", properties);
            ThingHelper.AddAsObjectArray(Employees, "employees", properties);
            ThingHelper.AddAsObjectArray(Events, "events", properties);
            ThingHelper.AddAsObjectArray(Founders, "founders", properties);
            ThingHelper.AddAsObjectArray(Location, "location", properties);
            ThingHelper.AddAsObjectArray(Members, "members", properties);
            ThingHelper.AddAsObjectArray(InteractionCount, "interactionCount", properties, x => x.ToJson());
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
            if (properties.TryGetValue("email", out value))
                Email = value.GetString();
            if (properties.TryGetValue("faxNumber", out value))
                FaxNumber = value.GetString();
            if (properties.TryGetValue("telephone", out value))
                Telephone = value.GetString();
            if (properties.TryGetValue("foundingDate", out value))
                FoundingDate = DateTimeHelper.FromString(value.GetString());

            Address = ThingHelper.GetObjectArray<IPostalAddress>(properties, "address");
            ContactPoints = ThingHelper.GetObjectArray<IContactPoint>(properties, "contactPoints");
            Employees = ThingHelper.GetObjectArray<IPerson>(properties, "employees");
            Events = ThingHelper.GetObjectArray<IEvent>(properties, "events");
            Founders = ThingHelper.GetObjectArray<IPerson>(properties, "founders");
            Location = ThingHelper.GetObjectArray<IPlace>(properties, "location");
            Members = ThingHelper.GetObjectArray<IOrganization>(properties, "members");

            InteractionCount = ThingHelper.GetObjectArray(properties, "interactionCount", x => UserInteraction.FromJson(x.GetObject()));
            Reviews = ThingHelper.GetObjectArray(properties, "reviews", x => Review.FromJson(x.GetObject()));

            if (properties.TryGetValue("aggregateRating", out value))
                AggregateRating = AggregateRating.FromJson(value.GetObject());

            return properties;
        }
    }
}