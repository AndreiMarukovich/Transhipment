using System;
using System.Collections.Generic;

namespace Transhipment
{
	public interface IPerson : IThing
	{
		string AdditionalName { get; set; }
		IList<IPostalAddress> PostalAddress { get; }
		IList<IOrganization> Affiliation { get; }
		IList<IOrganization> AlumniOf { get; }
		IList<string> Awards { get; }
        DateTimeOffset? BirthDate { get; set; }
		IList<IPerson> Children { get; }
		IList<IPerson> Colleagues { get; }
		IList<IContactPoint> ContactPoints { get; }
        DateTimeOffset? DeathDate { get; set; }
		string Email { get; set; }
		string FamilyName { get; set; }
		string FaxNumber { get; set; }
		IList<IPerson> Follows { get; }
		string Gender { get; set; }
		string GivenName { get; set; }
		IList<IPlace> HomeLocation { get; }
		string HonorificPrefix { get; set; }
		string HonorificSuffix { get; set; }
		IList<UserInteraction> InteractionCount { get; }
		IList<string> JobTitles { get; }
		IList<IPerson> Knows { get; }
		IList<IOrganization> MemberOf { get; }
		string Nationality { get; set; }
		IList<IPerson> Parents { get; }
		IList<IEvent> PerformerIn { get; }
		IList<IPerson> RelatedTo { get; }
		IList<IPerson> Siblings { get; }
		IList<IPerson> Spouse { get; }
		string Telephone { get; set; }
		IList<IPlace> WorkLocation { get; }
		IList<IOrganization> WorksFor { get; }
	}
}