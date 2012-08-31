using System.Collections.Generic;
using Transhipment.Helpers;
using Windows.Data.Json;

namespace Transhipment.Implementation
{
    class Movie : CreativeWork, IMovie
    {
        public override string Type
        {
            get { return Schema.Movie; }
        }

        public IList<IPerson> Actors { get; private set; }
        public IPerson Director { get; set; }
        public int Duration { get; set; }
        public IList<IMusicGroup> MusicBy { get; set; }
        public IPerson Producer { get; set; }
        public IOrganization ProductionCompany { get; set; }

        public Movie()
        {
            Actors = new List<IPerson>();
            MusicBy = new List<IMusicGroup>();
        }

        internal override JsonObject ToJson(out JsonObject properties)
        {
            var json = base.ToJson(out properties);

            properties.Add("duration", JsonValue.CreateNumberValue(Duration));
            ThingHelper.AddAsObjectArray(Actors, "actors", properties);
            ThingHelper.AddAsObjectArray(MusicBy, "musicBy", properties);

            ThingHelper.AddAsObject(Director, "director", properties);
            ThingHelper.AddAsObject(Producer, "producer", properties);
            ThingHelper.AddAsObject(ProductionCompany, "productionCompany", properties);

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

            Actors = ThingHelper.GetObjectArray<IPerson>(properties, "actors");
            MusicBy = ThingHelper.GetObjectArray<IMusicGroup>(properties, "musicBy");

            if (properties.TryGetValue("director", out value))
                Director = SchemaFactory.Parse(value.GetObject()) as IPerson;
            if (properties.TryGetValue("producer", out value))
                Producer = SchemaFactory.Parse(value.GetObject()) as IPerson;
            if (properties.TryGetValue("productionCompany", out value))
                ProductionCompany = SchemaFactory.Parse(value.GetObject()) as IOrganization;

            return properties;
        }
    }
}