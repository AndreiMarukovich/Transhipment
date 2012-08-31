using System;
using System.Collections.Generic;
using Transhipment.Helpers;
using Windows.Data.Json;

namespace Transhipment.Implementation
{
    class Event : Thing, IEvent
    {
        public override string Type
        {
            get { return Schema.Event; }
        }

        public IList<IPerson> Attendees { get; private set; }
        public int Duration { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public IList<IPlace> Location { get; private set; }
        public IList<IPerson> Performers { get; private set; }
        public DateTimeOffset? StartDate { get; set; }
        public IList<IEvent> SubEvents { get; private set; }

        public Event()
        {
            Attendees = new List<IPerson>();
            Location = new List<IPlace>();
            Performers = new List<IPerson>();
            SubEvents = new List<IEvent>();
        }

        internal override JsonObject ToJson(out JsonObject properties)
        {
            var json = base.ToJson(out properties);

            ThingHelper.AddAsObjectArray(Attendees, "attendees", properties);
            ThingHelper.AddAsObjectArray(Location, "location", properties);
            ThingHelper.AddAsObjectArray(Performers, "performers", properties);
            ThingHelper.AddAsObjectArray(SubEvents, "subEvents", properties);

            properties.Add("duration", JsonValue.CreateNumberValue(Duration));
            properties.Add("endDate", JsonValue.CreateStringValue(DateTimeHelper.ToString(EndDate)));
            properties.Add("startDate", JsonValue.CreateStringValue(DateTimeHelper.ToString(StartDate)));

            return json;
        }

        internal override JsonObject PopulateFromJson(JsonObject jsonObject)
        {
            var properties = base.PopulateFromJson(jsonObject);
            if (properties == null)
                return null;

            IJsonValue value;
            if (properties.TryGetValue("duration", out value))
                Duration = (int)value.GetNumber();
            if (properties.TryGetValue("endDate", out value))
                EndDate = DateTimeHelper.FromString(value.GetString());
            if (properties.TryGetValue("startDate", out value))
                StartDate = DateTimeHelper.FromString(value.GetString());

            Attendees = ThingHelper.GetObjectArray<IPerson>(properties, "attendees");
            Location = ThingHelper.GetObjectArray<IPlace>(properties, "location");
            Performers = ThingHelper.GetObjectArray<IPerson>(properties, "performers");
            SubEvents = ThingHelper.GetObjectArray<IEvent>(properties, "subEvents");

            return properties;
        }
    }
}