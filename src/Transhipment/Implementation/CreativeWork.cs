using System;
using System.Collections.Generic;
using Transhipment.Helpers;
using Windows.Data.Json;

namespace Transhipment.Implementation
{
	class CreativeWork : Thing, ICreativeWork
	{
        public override string Type
        {
            get { return Schema.CreativeWork; }
        }

	    public IThing About { get; set; }
	    public IPerson AccountablePerson { get; set; }
	    public AggregateRating AggregateRating { get; set; }
	    public string AlternativeHeadline { get; set; }
	    public IList<IPerson> Author { get; private set; }
	    public IList<string> Awards { get; private set; }
	    public IPlace ContentLocation { get; set; }
	    public string ContentRating { get; set; }
	    public IList<IPerson> Contributors { get; private set; }
	    public string CopyrightHolder { get; set; }
	    public int CopyrightYear { get; set; }
	    public DateTimeOffset? DateCreated { get; set; }
	    public DateTimeOffset? DateModified { get; set; }
	    public DateTimeOffset? DatePublished { get; set; }
	    public string DiscussionUrl { get; set; }
	    public IPerson Editor { get; set; }
	    public IList<string> Genre { get; private set; }
	    public string Headline { get; set; }
	    public string InLanguage { get; set; }
	    public IList<UserInteraction> InteractionCount { get; private set; }
	    public bool IsFamilyFriendly { get; set; }
	    public IList<string> Keywords { get; private set; }
	    public IOrganization Publisher { get; set; }
	    public IList<Review> Reviews { get; private set; }
	    public IOrganization SourceOrganization { get; set; }
	    public string Text { get; set; }
	    public string ThumbnailUrl { get; set; }
	    public string Version { get; set; }

	    public CreativeWork()
	    {
	        Author = new List<IPerson>();
            Awards = new List<string>();
            Contributors = new List<IPerson>();
            Genre = new List<string>();
            InteractionCount = new List<UserInteraction>();
            Keywords = new List<string>();
            Reviews = new List<Review>();
	    }

        internal override JsonObject ToJson(out JsonObject properties)
        {
            var json = base.ToJson(out properties);

            properties.Add("alternativeHeadline", JsonValue.CreateStringValue(AlternativeHeadline ?? String.Empty));
            properties.Add("contentRating", JsonValue.CreateStringValue(ContentRating ?? String.Empty));
            properties.Add("copyrightHolder", JsonValue.CreateStringValue(CopyrightHolder ?? String.Empty));
            properties.Add("copyrightYear", JsonValue.CreateNumberValue(CopyrightYear));
            properties.Add("dateCreated", JsonValue.CreateStringValue(DateTimeHelper.ToString(DateCreated)));
            properties.Add("dateModified", JsonValue.CreateStringValue(DateTimeHelper.ToString(DateModified)));
            properties.Add("datePublished", JsonValue.CreateStringValue(DateTimeHelper.ToString(DatePublished)));
            properties.Add("discussionUrl", JsonValue.CreateStringValue(DiscussionUrl ?? String.Empty));
            properties.Add("headline", JsonValue.CreateStringValue(Headline ?? String.Empty));
            properties.Add("inLanguage", JsonValue.CreateStringValue(InLanguage ?? String.Empty));
            properties.Add("isFamilyFriendly", JsonValue.CreateBooleanValue(IsFamilyFriendly));
            properties.Add("text", JsonValue.CreateStringValue(Text ?? String.Empty));
            properties.Add("thumbnailUrl", JsonValue.CreateStringValue(ThumbnailUrl ?? String.Empty));
            properties.Add("version", JsonValue.CreateStringValue(Version ?? String.Empty));

            ThingHelper.AddAsObject(About, "about", properties);
            ThingHelper.AddAsObject(AccountablePerson, "accountablePerson", properties);
            ThingHelper.AddAsObject(ContentLocation, "contentLocation", properties);
            ThingHelper.AddAsObject(Editor, "editor", properties);
            ThingHelper.AddAsObject(Publisher, "publisher", properties);
            ThingHelper.AddAsObject(SourceOrganization, "sourceOrganization", properties);

            ThingHelper.AddAsObjectArray(Author, "author", properties);
            ThingHelper.AddAsObjectArray(Contributors, "contributors", properties); 
            ThingHelper.AddAsObjectArray(Awards, "awards", properties, JsonValue.CreateStringValue);
            ThingHelper.AddAsObjectArray(Genre, "genre", properties, JsonValue.CreateStringValue);
            ThingHelper.AddAsObjectArray(Keywords, "keywords", properties, JsonValue.CreateStringValue);
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
            if (properties.TryGetValue("alternativeHeadline", out value))
                AlternativeHeadline = value.GetString();
            if (properties.TryGetValue("contentRating", out value))
                ContentRating = value.GetString();
            if (properties.TryGetValue("copyrightHolder", out value))
                CopyrightHolder = value.GetString();
            if (properties.TryGetValue("copyrightYear", out value))
                CopyrightYear = (int)value.GetNumber();
            if (properties.TryGetValue("dateCreated", out value))
                DateCreated = DateTimeHelper.FromString(value.GetString());
            if (properties.TryGetValue("dateModified", out value))
                DateModified = DateTimeHelper.FromString(value.GetString());
            if (properties.TryGetValue("datePublished", out value))
                DatePublished = DateTimeHelper.FromString(value.GetString());
            if (properties.TryGetValue("discussionUrl", out value))
                DiscussionUrl = value.GetString();
            if (properties.TryGetValue("headline", out value))
                Headline = value.GetString();
            if (properties.TryGetValue("inLanguage", out value))
                InLanguage = value.GetString();
            if (properties.TryGetValue("isFamilyFriendly", out value))
                IsFamilyFriendly = value.GetBoolean();
            if (properties.TryGetValue("text", out value))
                Text = value.GetString();
            if (properties.TryGetValue("thumbnailUrl", out value))
                ThumbnailUrl = value.GetString();
            if (properties.TryGetValue("version", out value))
                Version = value.GetString();

            if (properties.TryGetValue("about", out value))
                About = SchemaFactory.Parse(value.GetObject());
            if (properties.TryGetValue("accountablePerson", out value))
                AccountablePerson = SchemaFactory.Parse(value.GetObject()) as IPerson;
            if (properties.TryGetValue("contentLocation", out value))
                ContentLocation = SchemaFactory.Parse(value.GetObject()) as IPlace;
            if (properties.TryGetValue("editor", out value))
                Editor = SchemaFactory.Parse(value.GetObject()) as IPerson;
            if (properties.TryGetValue("publisher", out value))
                Publisher = SchemaFactory.Parse(value.GetObject()) as IOrganization;
            if (properties.TryGetValue("sourceOrganization", out value))
                SourceOrganization = SchemaFactory.Parse(value.GetObject()) as IOrganization;

            Author = ThingHelper.GetObjectArray<IPerson>(properties, "author");
            Contributors = ThingHelper.GetObjectArray<IPerson>(properties, "contributors");

            Awards = ThingHelper.GetObjectArray(properties, "awards", x => x.GetString());
            Genre = ThingHelper.GetObjectArray(properties, "genre", x => x.GetString());
            Keywords = ThingHelper.GetObjectArray(properties, "keywords", x => x.GetString());
            InteractionCount = ThingHelper.GetObjectArray(properties, "interactionCount", x => UserInteraction.FromJson(x.GetObject()));
            Reviews = ThingHelper.GetObjectArray(properties, "reviews", x => Review.FromJson(x.GetObject()));

            if (properties.TryGetValue("aggregateRating", out value))
                AggregateRating = AggregateRating.FromJson(value.GetObject());

            return properties;
        }
	}
}
