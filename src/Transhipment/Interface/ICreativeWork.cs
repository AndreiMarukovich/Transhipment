using System;
using System.Collections.Generic;

namespace Transhipment
{
	public interface ICreativeWork : IThing
	{
        /// <summary>
        /// The subject matter of the content.
        /// </summary>
        IThing About { get; set; }
        /// <summary>
        /// Specifies the Person that is legally accountable for the CreativeWork.
        /// </summary>
        IPerson AccountablePerson { get; set; }
        /// <summary>
        /// The overall rating, based on a collection of reviews or ratings, of the item.
        /// </summary>
        AggregateRating AggregateRating { get; set; }
        /// <summary>
        /// A secondary title of the CreativeWork.
        /// </summary>
        string AlternativeHeadline { get; set; }
        /// <summary>
        /// The author of this content.
        /// </summary>
        IList<IPerson> Author { get; }
        /// <summary>
        /// Awards won by this person or for this creative work.
        /// </summary>
        IList<string> Awards { get; }
        /// <summary>
        /// The location of the content.
        /// </summary>
        IPlace ContentLocation { get; set; }
        /// <summary>
        /// Official rating of a piece of content—for example,'MPAA PG-13'.
        /// </summary>
        string ContentRating { get; set; }
        /// <summary>
        /// Secondary contributor to the CreativeWork.
        /// </summary>
        IList<IPerson> Contributors { get; }
        /// <summary>
        /// The party holding the legal copyright to the CreativeWork.
        /// </summary>
        string CopyrightHolder { get; set; }
        /// <summary>
        /// The year during which the claimed copyright for the CreativeWork was first asserted.
        /// </summary>
        int CopyrightYear { get; set; }
        /// <summary>
        /// The date on which the CreativeWork was created.
        /// </summary>
        DateTimeOffset? DateCreated { get; set; }
        /// <summary>
        /// The date on which the CreativeWork was most recently modified.
        /// </summary>
        DateTimeOffset? DateModified { get; set; }
        /// <summary>
        /// Date of first broadcast/publication.
        /// </summary>
        DateTimeOffset? DatePublished { get; set; }
        /// <summary>
        /// A link to the page containing the comments of the CreativeWork.
        /// </summary>
        string DiscussionUrl { get; set; }
        /// <summary>
        /// Specifies the Person who edited the CreativeWork.
        /// </summary>
        IPerson Editor { get; set; }
        /// <summary>
        /// Genre of the creative work
        /// </summary>
        IList<string> Genre { get; }
        /// <summary>
        /// Headline of the article
        /// </summary>
        string Headline { get; set; }
        /// <summary>
        /// The language of the content. please use one of the language codes from the IETF BCP 47 standard.
        /// </summary>
        string InLanguage { get; set; }
        /// <summary>
        /// A count of a specific user interactions with this item—for example, 5 UserComments.
        /// </summary>
        IList<UserInteraction> InteractionCount { get; }
        /// <summary>
        /// Indicates whether this content is family friendly.
        /// </summary>
        bool IsFamilyFriendly { get; set; }
        /// <summary>
        /// The keywords/tags used to describe this content.
        /// </summary>
	    IList<string> Keywords { get; }
        /// <summary>
        /// The publisher of the creative work.
        /// </summary>
        IOrganization Publisher { get; set; }
        /// <summary>
        /// Review of the item 
        /// </summary>
	    IList<Review> Reviews { get; }
        /// <summary>
        /// The Organization on whose behalf the creator was working.
        /// </summary>
        IOrganization SourceOrganization { get; set; }
        /// <summary>
        /// The textual content of this CreativeWork.
        /// </summary>
        string Text { get; set; }
        /// <summary>
        /// A thumbnail image relevant to the Thing.
        /// </summary>
        string ThumbnailUrl { get; set; }
        /// <summary>
        /// The version of the CreativeWork embodied by a specified resource.
        /// </summary>
        string Version { get; set; }
	}
}