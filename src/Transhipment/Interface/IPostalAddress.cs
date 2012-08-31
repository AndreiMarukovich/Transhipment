namespace Transhipment
{
	public interface IPostalAddress : IThing
	{
		/// <summary>
		/// The country. For example, USA. You can also provide the two-letter ISO 3166-1 alpha-2 country code.
		/// </summary>
		string AddressCountry { get; set; }
		/// <summary>
		/// The locality. For example, Mountain View.
		/// </summary>
		string AddressLocality { get; set; }
		/// <summary>
		/// The region. For example, CA.
		/// </summary>
		string AddressRegion { get; set; }
		/// <summary>
		/// The post offce box number for PO box addresses.
		/// </summary>
		string PostOfficeBoxNumber { get; set; }
		/// <summary>
		/// The postal code. For example, 94043.
		/// </summary>
		string PostalCode { get; set; }
		/// <summary>
		/// The street address. For example, 1600 Amphitheatre Pkwy.
		/// </summary>
		string StreetAddress { get; set; }
	}
}