using System;
using System.Collections.Generic;

namespace Transhipment
{
	public interface IOrganization : IThing
	{
		IList<IPostalAddress> Address { get; }
        AggregateRating AggregateRating { get; set; }
		IList<IContactPoint> ContactPoints { get; }
		string Email { get; set; }
		IList<IPerson> Employees { get; }
		IList<IEvent> Events { get; }
		string FaxNumber { get; set; }
		IList<IPerson> Founders { get; }
		DateTimeOffset? FoundingDate { get; set; }
		IList<UserInteraction> InteractionCount { get; }
		IList<IPlace> Location { get; }
		IList<IOrganization> Members { get; }
		IList<Review> Reviews { get; }
		string Telephone { get; set; }
	}
}