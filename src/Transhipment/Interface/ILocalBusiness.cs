using System.Collections.Generic;

namespace Transhipment
{
	public interface ILocalBusiness : IOrganization
	{
        /// <summary>
        /// The larger organization that this local business is a branch of, if any.
        /// </summary>
        IOrganization BranchOf { get; set; }
        /// <summary>
        /// The currency accepted (in ISO 4217 currency format).
        /// </summary>
        string CurrenciesAccepted { get; set; }
        /// <summary>
        /// The opening hours for a business.
        /// </summary>
        IList<OpeningHours> OpeningHours { get; }
        /// <summary>
        /// Cash, credit card, etc.
        /// </summary>
        IList<string> PaymentAccepted { get; }
        /// <summary>
        /// The price range of the business, for example $$$.
        /// </summary>
        string PriceRange { get; set; }
        /// <summary>
        /// The basic containment relation between places.
        /// </summary>
        IPlace ContainedIn { get; set; }
        /// <summary>
        /// The geo coordinates of the place.
        /// </summary>
        IGeoCoordinates Geo { get; }
        /// <summary>
        /// A URL to a map of the place.
        /// </summary>
        IList<string> Map { get; }
        /// <summary>
        /// A URL to a photo of the place.
        /// </summary>
        IList<string> Photos { get; }

	}
}