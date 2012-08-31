using System.Collections.Generic;

namespace Transhipment
{
	public interface IMusicAlbum : IMusicPlaylist
	{
	    IList<IMusicGroup> ByArtist { get; }
	}
}