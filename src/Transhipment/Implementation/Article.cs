using System;
using Windows.Data.Json;

namespace Transhipment.Implementation
{
    class Article : CreativeWork, IArticle
    {
        public override string Type
        {
            get { return Schema.Article; }
        }
        public string ArticleBody { get; set; }
        public string ArticleSection { get; set; }
        public int WordCount { get; set; }

        internal override JsonObject ToJson(out JsonObject properties)
        {
            var json = base.ToJson(out properties);

            properties.Add("articleBody", JsonValue.CreateStringValue(ArticleBody ?? String.Empty));
            properties.Add("articleSection", JsonValue.CreateStringValue(ArticleSection ?? String.Empty));
            properties.Add("wordCount", JsonValue.CreateNumberValue(WordCount));
            return json;
        }

        internal override JsonObject PopulateFromJson(JsonObject jsonObject)
        {
            var properties = base.PopulateFromJson(jsonObject);
            if (properties == null)
                return null;

            IJsonValue value;
            if (properties.TryGetValue("articleBody", out value))
                ArticleBody = value.GetString();
            if (properties.TryGetValue("articleSection", out value))
                ArticleSection = value.GetString();
            if (properties.TryGetValue("wordCount", out value))
                WordCount = (int)value.GetNumber();
            
            return properties;
        }
    }
}