using System;
using Windows.Data.Json;

namespace Transhipment.Implementation
{
	class ContactPoint : Thing, IContactPoint
	{
		public override string Type
		{
			get { return Schema.ContactPoint; }
		}

		public string ContactType { get; set; }
		public string Email { get; set; }
		public string FaxNumber { get; set; }
		public string Telephone { get; set; }

		public ContactPoint()
		{
			ContactType = String.Empty;
			Email = String.Empty;
			FaxNumber = String.Empty;
			Telephone = String.Empty;
		}

        internal override JsonObject ToJson(out JsonObject properties)
		{
			var json = base.ToJson(out properties);

			properties.Add("contactType", JsonValue.CreateStringValue(ContactType));
			properties.Add("email", JsonValue.CreateStringValue(Email));
			properties.Add("faxNumber", JsonValue.CreateStringValue(FaxNumber));
			properties.Add("telephone", JsonValue.CreateStringValue(Telephone));

			return json;
		}

		internal override JsonObject PopulateFromJson(JsonObject jsonObject)
		{
			var properties = base.PopulateFromJson(jsonObject);
			if (properties == null)
				return null;

			IJsonValue value;
			if (properties.TryGetValue("contactType", out value))
				ContactType = value.GetString();
			if (properties.TryGetValue("email", out value))
				Email = value.GetString();
			if (properties.TryGetValue("faxNumber", out value))
				FaxNumber = value.GetString();
			if (properties.TryGetValue("telephone", out value))
				Telephone = value.GetString();

			return properties;
		}
	}
}