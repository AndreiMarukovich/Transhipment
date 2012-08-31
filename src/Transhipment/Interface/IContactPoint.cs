namespace Transhipment
{
	public interface IContactPoint : IThing
	{
		string ContactType { get; set; }
		string Email { get; set; }
		string FaxNumber { get; set; }
		string Telephone { get; set; }
	}
}