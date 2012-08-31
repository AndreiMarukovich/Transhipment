using System.Collections.Generic;

namespace Transhipment
{
	public interface IMovie : ICreativeWork
	{
	    IList<IPerson> Actors { get; }
        IPerson Director { get; set; }
        int Duration { get; set; }
        IList<IMusicGroup> MusicBy { get; set; }
        IPerson Producer { get; set; }
        IOrganization ProductionCompany { get; set; }
	}
}