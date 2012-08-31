using System;
using Windows.Data.Json;

namespace Transhipment.Implementation
{
	class GeoCoordinates : Thing, IGeoCoordinates
	{
		public override string Type
		{
			get { return Schema.GeoCoordinates; } 
		}

		public string Elevation { get; set; }
		public string Latitude { get; set; }
		public string Longitude { get; set; }

		public GeoCoordinates()
		{
			Elevation = String.Empty;
			Latitude = String.Empty;
			Longitude = String.Empty;
		}

        internal override JsonObject ToJson(out JsonObject properties)
		{
			var json = base.ToJson(out properties);

			properties.Add("elevation", JsonValue.CreateStringValue(Elevation));
			properties.Add("latitude", JsonValue.CreateStringValue(Latitude));
			properties.Add("longitude", JsonValue.CreateStringValue(Longitude));

			return json;
		}

		internal override JsonObject PopulateFromJson(JsonObject jsonObject)
		{
			var properties = base.PopulateFromJson(jsonObject);
			if (properties == null)
				return null;

			IJsonValue value;
			if (properties.TryGetValue("elevation", out value))
				Elevation = value.GetString();
			if (properties.TryGetValue("latitude", out value))
				Latitude = value.GetString();
			if (properties.TryGetValue("longitude", out value))
				Longitude = value.GetString();

			return properties;
		}
	}
}