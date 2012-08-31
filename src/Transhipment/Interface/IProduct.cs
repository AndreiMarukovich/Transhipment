using System.Collections.Generic;

namespace Transhipment
{
	public interface IProduct : IThing
	{
        AggregateRating AggregateRating { get; set; }
        IOrganization Brand { get; set; }
        IOrganization Manufacturer { get; set; }
        string Model { get; set; }
        string ProductId { get; set; }
        IList<Review> Reviews { get; }
	}
}