using Windows.Data.Json;

namespace Transhipment.Implementation
{
	internal class Thing : IThing
	{
		public virtual string Type
		{
			get { return Schema.Thing; }
		}

		public string AdditionalType { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }
		public string Name { get; set; }
		public string Url { get; set; }

		public Thing()
		{
			AdditionalType = string.Empty;
			Description = string.Empty;
			Image = string.Empty;
			Name = string.Empty;
			Url = string.Empty;
		}

		internal virtual JsonObject ToJson(out JsonObject properties)
		{
			var json = new JsonObject { { "type", JsonValue.CreateStringValue(Type) } };

			properties = new JsonObject
                             {
                                 {"additionalType", JsonValue.CreateStringValue(AdditionalType)},
                                 {"description", JsonValue.CreateStringValue(Description)},
                                 {"image", JsonValue.CreateStringValue(Image)},
                                 {"name", JsonValue.CreateStringValue(Name)},
                                 {"url", JsonValue.CreateStringValue(Url)}
                             };
			json.Add("properties", properties);

			return json;
		}

		internal virtual JsonObject PopulateFromJson(JsonObject jsonObject)
		{
			IJsonValue value;
			if (!jsonObject.TryGetValue("properties", out value))
				return null;

			var properties = value.GetObject();
			if (properties == null)
				return null;

			if (properties.TryGetValue("additionalType", out value))
				AdditionalType = value.GetString();
			if (properties.TryGetValue("description", out value))
				Description = value.GetString();
			if (properties.TryGetValue("image", out value))
				Image = value.GetString();
			if (properties.TryGetValue("name", out value))
				Name = value.GetString();
			if (properties.TryGetValue("url", out value))
				Url = value.GetString();

			return properties;
		}

		public string Stringify()
		{
			JsonObject properties;
			return ToJson(out properties).Stringify();
		}
	}

}
