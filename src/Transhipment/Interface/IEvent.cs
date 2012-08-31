using System;
using System.Collections.Generic;

namespace Transhipment
{
	public interface IEvent : IThing
	{
        /// <summary>
        /// Person attending the event
        /// </summary>
	    IList<IPerson> Attendees { get; }
        /// <summary>
        /// Duration in minutes
        /// </summary>
        int Duration { get; set; }
        /// <summary>
        /// The end date and time of the event
        /// </summary>
        DateTimeOffset? EndDate { get; set; }
        /// <summary>
        /// Location of the event
        /// </summary>
        IList<IPlace> Location { get; }
        /// <summary>
        /// The main performer or performers of the event
        /// </summary>
        IList<IPerson> Performers { get; }
        /// <summary>
        /// The start date and time of the event
        /// </summary>
        DateTimeOffset? StartDate { get; set; }
        /// <summary>
        /// Events that are a part of this event. For example, a conference event includes many presentations.
        /// </summary>
	    IList<IEvent> SubEvents { get; }
	}
}