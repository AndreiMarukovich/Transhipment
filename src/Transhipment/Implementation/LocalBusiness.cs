using System;
using System.Collections.Generic;
using System.Text;
using Transhipment.Helpers;
using Windows.Data.Json;

namespace Transhipment.Implementation
{
    class LocalBusiness : Organization, ILocalBusiness
    {
        public override string Type
        {
            get { return Schema.LocalBusiness; }
        }

        public IOrganization BranchOf { get; set; }
        public string CurrenciesAccepted { get; set; }
        public IList<OpeningHours> OpeningHours { get; private set; }
        public IList<string> PaymentAccepted { get; private set; }
        public string PriceRange { get; set; }
        public IPlace ContainedIn { get; set; }
        public IGeoCoordinates Geo { get; private set; }
        public IList<string> Map { get; private set; }
        public IList<string> Photos { get; private set; }

        public LocalBusiness()
        {
            OpeningHours = new List<OpeningHours>();
            PaymentAccepted = new List<string>();
            Map = new List<string>();
            Photos = new List<string>();
        }

        internal override JsonObject ToJson(out JsonObject properties)
        {
            var json = base.ToJson(out properties);

            properties.Add("currenciesAccepted", JsonValue.CreateStringValue(CurrenciesAccepted ?? String.Empty));
            properties.Add("priceRange", JsonValue.CreateStringValue(PriceRange ?? String.Empty));

            ThingHelper.AddAsObject(BranchOf, "branchOf", properties);
            ThingHelper.AddAsObject(ContainedIn, "containedIn", properties);
            ThingHelper.AddAsObject(Geo, "geo", properties);

            ThingHelper.AddAsObjectArray(PaymentAccepted, "paymentAccepted", properties, JsonValue.CreateStringValue);
            ThingHelper.AddAsObjectArray(Map, "map", properties, JsonValue.CreateStringValue);
            ThingHelper.AddAsObjectArray(Photos, "photos", properties, JsonValue.CreateStringValue);

            var sb = new StringBuilder();
            foreach (var opening in OpeningHours)
            {
                sb.AppendFormat("{0},", opening.ToString());
            }
            properties.Add("openingHours", JsonValue.CreateStringValue(sb.ToString()));

            return json;
        }

        internal override JsonObject PopulateFromJson(JsonObject jsonObject)
        {
            var properties = base.PopulateFromJson(jsonObject);
            if (properties == null)
                return null;

            IJsonValue value;
            if (properties.TryGetValue("currenciesAccepted", out value))
                CurrenciesAccepted = value.GetString();
            if (properties.TryGetValue("priceRange", out value))
                PriceRange = value.GetString();

            if (properties.TryGetValue("branchOf", out value))
                BranchOf = SchemaFactory.Parse(value.GetObject()) as IOrganization;
            if (properties.TryGetValue("containedIn", out value))
                ContainedIn = SchemaFactory.Parse(value.GetObject()) as IPlace;
            if (properties.TryGetValue("geo", out value))
                Geo = SchemaFactory.Parse(value.GetObject()) as IGeoCoordinates;

            PaymentAccepted = ThingHelper.GetObjectArray(properties, "paymentAccepted", x => x.GetString());
            Map = ThingHelper.GetObjectArray(properties, "map", x => x.GetString());
            Photos = ThingHelper.GetObjectArray(properties, "photos", x => x.GetString());

            if (properties.TryGetValue("openingHours", out value))
            {
                var parts = value.GetString().Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                foreach (var part in parts)
                {
                    OpeningHours.Add(Transhipment.OpeningHours.FromString(part));
                }
            }

            return properties;
        }
    }
}