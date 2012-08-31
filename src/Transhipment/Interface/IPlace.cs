using System.Collections.Generic;

namespace Transhipment
{
	public interface IPlace : IThing
	{
        IPostalAddress Address { get; set; }
        /// <summary>
        /// The overall rating, based on a collection of reviews or ratings, of the item.
        /// </summary>
        AggregateRating AggregateRating { get; set; }
        /// <summary>
        /// The basic containment relation between places.
        /// </summary>
        IPlace ContainedIn { get; set; }
        /// <summary>
        /// Upcoming or past events associated with this place or organization.
        /// </summary>
        IList<IEvent> Events { get; }
        /// <summary>
        /// The fax number.
        /// </summary>
        string FaxNumber { get; set; }
        /// <summary>
        /// The geo coordinates of the place.
        /// </summary>
        IGeoCoordinates Geo { get; set; }
        /// <summary>
        /// A count of a specific user interactions with this item — for example, 20 UserLikes.
        /// </summary>
	    IList<UserInteraction> InteractionCount { get; }
        /// <summary>
        /// A URL to a map of the place.
        /// </summary>
        IList<string> Map { get; }
        /// <summary>
        /// A URL to a photo of the place.
        /// </summary>
        IList<string> Photos { get; }
        /// <summary>
        /// Review of the item.
        /// </summary>
        IList<Review> Reviews { get; }
        /// <summary>
        /// The telephone number.
        /// </summary>
        string Telephone { get; set; }
	}
}