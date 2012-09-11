using System.Collections.Generic;
using Windows.Data.Json;

namespace Transhipment.Implementation
{
	internal class Thing : IThing
	{
		public virtual string Type
		{
			get { return Schema.Thing; }
		}

	    public int Revision { get; set; }
        
        public string AdditionalType { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }
		public string Name { get; set; }
		public string Url { get; set; }

        public IDictionary<string, string> ExtendedProperties { get; private set; }

		public Thing()
		{
		    Revision = 1;

			AdditionalType = string.Empty;
			Description = string.Empty;
			Image = string.Empty;
			Name = string.Empty;
			Url = string.Empty;

            ExtendedProperties = new Dictionary<string, string>();
		}

		internal virtual JsonObject ToJson(out JsonObject properties)
		{
		    var json = new JsonObject
		                   {
		                       {"type", JsonValue.CreateStringValue(Type)},
		                       {"revision", JsonValue.CreateNumberValue(Revision)}
		                   };

			properties = new JsonObject
                             {
                                 {"additionalType", JsonValue.CreateStringValue(AdditionalType ?? string.Empty)},
                                 {"description", JsonValue.CreateStringValue(Description ?? string.Empty)},
                                 {"image", JsonValue.CreateStringValue(Image ?? string.Empty)},
                                 {"name", JsonValue.CreateStringValue(Name ?? string.Empty)},
                                 {"url", JsonValue.CreateStringValue(Url ?? string.Empty)},
                             };
			json.Add("properties", properties);

            if (ExtendedProperties.Count != 0)
            {
                var extFields = new JsonObject();
                foreach (var field in ExtendedProperties)
                {
                    extFields.Add(field.Key, JsonValue.CreateStringValue(field.Value));
                }
                json.Add("extendedProperties", extFields);
            }

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
            if (properties.TryGetValue("revision", out value))
                Revision = (int)value.GetNumber();

            if (properties.TryGetValue("extendedProperties", out value))
            {
                ExtendedProperties.Clear();
                var fieldsObject = value.GetObject();
                foreach (var field in fieldsObject)
                {
                    ExtendedProperties.Add(field.Key, field.Value.GetString());
                }
            }


			return properties;
		}

		public string Stringify()
		{
			JsonObject properties;
			return ToJson(out properties).Stringify();
		}
	}

}
