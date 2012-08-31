using System;
using System.Collections.Generic;
using Transhipment.Helpers;
using Windows.Data.Json;

namespace Transhipment.Implementation
{
    class Person : Thing, IPerson
    {
        public override string Type
        {
            get { return Schema.Person; }
        }

        public string AdditionalName { get; set; }
        public IList<IPostalAddress> PostalAddress { get; private set; }
        public IList<IOrganization> Affiliation { get; private set; }
        public IList<IOrganization> AlumniOf { get; private set; }
        public IList<string> Awards { get; private set; }
        public DateTimeOffset? BirthDate { get; set; }
        public IList<IPerson> Children { get; private set; }
        public IList<IPerson> Colleagues { get; private set; }
        public IList<IContactPoint> ContactPoints { get; private set; }
        public DateTimeOffset? DeathDate { get; set; }
        public string Email { get; set; }
        public string FamilyName { get; set; }
        public string FaxNumber { get; set; }
        public IList<IPerson> Follows { get; private set; }
        public string Gender { get; set; }
        public string GivenName { get; set; }
        public IList<IPlace> HomeLocation { get; private set; }
        public string HonorificPrefix { get; set; }
        public string HonorificSuffix { get; set; }
        public IList<UserInteraction> InteractionCount { get; set; }
        public IList<string> JobTitles { get; private set; }
        public IList<IPerson> Knows { get; private set; }
        public IList<IOrganization> MemberOf { get; private set; }
        public string Nationality { get; set; }
        public IList<IPerson> Parents { get; private set; }
        public IList<IEvent> PerformerIn { get; private set; }
        public IList<IPerson> RelatedTo { get; private set; }
        public IList<IPerson> Siblings { get; private set; }
        public IList<IPerson> Spouse { get; private set; }
        public string Telephone { get; set; }
        public IList<IPlace> WorkLocation { get; private set; }
        public IList<IOrganization> WorksFor { get; private set; }

        public Person()
        {
            PostalAddress = new List<IPostalAddress>();
            Affiliation = new List<IOrganization>();
            AlumniOf = new List<IOrganization>();
            Awards = new List<string>();
            Children = new List<IPerson>();
            Colleagues = new List<IPerson>();
            ContactPoints = new List<IContactPoint>();
            Follows = new List<IPerson>();
            HomeLocation = new List<IPlace>();
            InteractionCount = new List<UserInteraction>();
            JobTitles = new List<string>();
            Knows = new List<IPerson>();
            MemberOf = new List<IOrganization>();
            Parents = new List<IPerson>();
            PerformerIn = new List<IEvent>();
            RelatedTo = new List<IPerson>();
            Siblings = new List<IPerson>();
            Spouse = new List<IPerson>();
            WorkLocation = new List<IPlace>();
            WorksFor = new List<IOrganization>();
        }

        internal override JsonObject ToJson(out JsonObject properties)
        {
            var json = base.ToJson(out properties);

            properties.Add("additionalName", JsonValue.CreateStringValue(AdditionalName ?? String.Empty));
            properties.Add("email", JsonValue.CreateStringValue(Email ?? String.Empty));
            properties.Add("familyName", JsonValue.CreateStringValue(FamilyName ?? String.Empty));
            properties.Add("faxNumber", JsonValue.CreateStringValue(FaxNumber ?? String.Empty));
            properties.Add("gender", JsonValue.CreateStringValue(Gender ?? String.Empty));
            properties.Add("givenName", JsonValue.CreateStringValue(GivenName ?? String.Empty));
            properties.Add("honorificPrefix", JsonValue.CreateStringValue(HonorificPrefix ?? String.Empty));
            properties.Add("honorificSuffix", JsonValue.CreateStringValue(HonorificSuffix ?? String.Empty));
            properties.Add("nationality", JsonValue.CreateStringValue(Nationality ?? String.Empty));
            properties.Add("telephone", JsonValue.CreateStringValue(Telephone ?? String.Empty));

            ThingHelper.AddAsObjectArray(PostalAddress, "postalAddress", properties);
            ThingHelper.AddAsObjectArray(Affiliation, "affiliation", properties);
            ThingHelper.AddAsObjectArray(AlumniOf, "alumniOf", properties);
            ThingHelper.AddAsObjectArray(Awards, "awards", properties, JsonValue.CreateStringValue);
            ThingHelper.AddAsObjectArray(Children, "children", properties);
            ThingHelper.AddAsObjectArray(Colleagues, "colleagues", properties);
            ThingHelper.AddAsObjectArray(ContactPoints, "contactPoints", properties);
            ThingHelper.AddAsObjectArray(Follows, "follows", properties);
            ThingHelper.AddAsObjectArray(HomeLocation, "homeLocation", properties);
            ThingHelper.AddAsObjectArray(InteractionCount, "interactionCount", properties, x => x.ToJson());
            ThingHelper.AddAsObjectArray(JobTitles, "jobTitles", properties, JsonValue.CreateStringValue);
            ThingHelper.AddAsObjectArray(Knows, "knows", properties);
            ThingHelper.AddAsObjectArray(MemberOf, "memberOf", properties);
            ThingHelper.AddAsObjectArray(Parents, "parents", properties);
            ThingHelper.AddAsObjectArray(PerformerIn, "performerIn", properties);
            ThingHelper.AddAsObjectArray(RelatedTo, "relatedTo", properties);
            ThingHelper.AddAsObjectArray(Siblings, "siblings", properties);
            ThingHelper.AddAsObjectArray(Spouse, "spouse", properties);
            ThingHelper.AddAsObjectArray(WorkLocation, "workLocation", properties);
            ThingHelper.AddAsObjectArray(WorksFor, "worksFor", properties);

            return json;
        }

        internal override JsonObject PopulateFromJson(JsonObject jsonObject)
        {
            var properties = base.PopulateFromJson(jsonObject);
            if (properties == null)
                return null;

            IJsonValue value;
            if (properties.TryGetValue("additionalName", out value))
                AdditionalName = value.GetString();
            if (properties.TryGetValue("email", out value))
                Email = value.GetString();
            if (properties.TryGetValue("familyName", out value))
                FamilyName = value.GetString();
            if (properties.TryGetValue("faxNumber", out value))
                FaxNumber = value.GetString();
            if (properties.TryGetValue("gender", out value))
                Gender = value.GetString();
            if (properties.TryGetValue("givenName", out value))
                GivenName = value.GetString();
            if (properties.TryGetValue("honorificPrefix", out value))
                HonorificPrefix = value.GetString();
            if (properties.TryGetValue("honorificSuffix", out value))
                HonorificSuffix = value.GetString();
            if (properties.TryGetValue("nationality", out value))
                Nationality = value.GetString();
            if (properties.TryGetValue("telephone", out value))
                Telephone = value.GetString();

            PostalAddress = ThingHelper.GetObjectArray<IPostalAddress>(properties, "postalAddress");
            Affiliation = ThingHelper.GetObjectArray<IOrganization>(properties, "affiliation");
            AlumniOf = ThingHelper.GetObjectArray<IOrganization>(properties, "alumniOf");
            Children = ThingHelper.GetObjectArray<IPerson>(properties, "children");
            Colleagues = ThingHelper.GetObjectArray<IPerson>(properties, "colleagues");
            Follows = ThingHelper.GetObjectArray<IPerson>(properties, "follows");
            ContactPoints = ThingHelper.GetObjectArray<IContactPoint>(properties, "contactPoints");
            HomeLocation = ThingHelper.GetObjectArray<IPlace>(properties, "homeLocation");
            Knows = ThingHelper.GetObjectArray<IPerson>(properties, "knows");
            Parents = ThingHelper.GetObjectArray<IPerson>(properties, "parents");
            MemberOf = ThingHelper.GetObjectArray<IOrganization>(properties, "memberOf");
            PerformerIn = ThingHelper.GetObjectArray<IEvent>(properties, "performerIn");
            RelatedTo = ThingHelper.GetObjectArray<IPerson>(properties, "relatedTo");
            Siblings = ThingHelper.GetObjectArray<IPerson>(properties, "siblings");
            Spouse = ThingHelper.GetObjectArray<IPerson>(properties, "spouse");
            WorkLocation = ThingHelper.GetObjectArray<IPlace>(properties, "workLocation");
            WorksFor = ThingHelper.GetObjectArray<IOrganization>(properties, "worksFor");

            Awards = ThingHelper.GetObjectArray(properties, "awards", x=>x.GetString());
            JobTitles = ThingHelper.GetObjectArray(properties, "jobTitles", x => x.GetString());
            InteractionCount = ThingHelper.GetObjectArray(properties, "interactionCount", x => UserInteraction.FromJson(x.GetObject()));

            return properties;
        }

    }
}