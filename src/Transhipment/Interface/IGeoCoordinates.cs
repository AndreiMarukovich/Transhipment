namespace Transhipment
{
	public interface IGeoCoordinates : IThing
	{
		string Elevation { get; set; }
		string Latitude { get; set; }
		string Longitude { get; set; }
	}
}