using System;
using Windows.Data.Json;

namespace Transhipment.Implementation
{
	class PostalAddress : Thing, IPostalAddress
	{
		public override string Type
		{
			get { return Schema.PostalAddress; }
		}

		public string AddressCountry { get; set; }
		public string AddressLocality { get; set; }
		public string AddressRegion { get; set; }
		public string PostOfficeBoxNumber { get; set; }
		public string PostalCode { get; set; }
		public string StreetAddress { get; set; }

		public PostalAddress()
		{
			AddressCountry = String.Empty;
			AddressLocality = String.Empty;
			AddressRegion = String.Empty;
			PostOfficeBoxNumber = String.Empty;
			PostalCode = String.Empty;
			StreetAddress = String.Empty;
		}

        internal override JsonObject ToJson(out JsonObject properties)
		{
			var json = base.ToJson(out properties);

			properties.Add("addressCountry", JsonValue.CreateStringValue(AddressCountry));
			properties.Add("addressLocality", JsonValue.CreateStringValue(AddressLocality));
			properties.Add("addressRegion", JsonValue.CreateStringValue(AddressRegion));
			properties.Add("postOfficeBoxNumber", JsonValue.CreateStringValue(PostOfficeBoxNumber));
			properties.Add("postalCode", JsonValue.CreateStringValue(PostalCode));
			properties.Add("streetAddress", JsonValue.CreateStringValue(StreetAddress));

			return json;
		}

		internal override JsonObject PopulateFromJson(JsonObject jsonObject)
		{
			var properties = base.PopulateFromJson(jsonObject);
			if (properties == null)
				return null;

			IJsonValue value;
			if (properties.TryGetValue("addressCountry", out value))
				AddressCountry = value.GetString();
			if (properties.TryGetValue("addressLocality", out value))
				AddressLocality = value.GetString();
			if (properties.TryGetValue("addressRegion", out value))
				AddressRegion = value.GetString();
			if (properties.TryGetValue("postOfficeBoxNumber", out value))
				PostOfficeBoxNumber = value.GetString();
			if (properties.TryGetValue("postalCode", out value))
				PostalCode = value.GetString();
			if (properties.TryGetValue("streetAddress", out value))
				StreetAddress = value.GetString();

			return properties;
		}
	}
}