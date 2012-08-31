using System.Collections.Generic;

namespace Transhipment
{
	public interface IMusicGroup : IOrganization
	{
	    IList<IMusicAlbum> Albums { get; }
	    IList<IPerson> MusicGroupMember { get; }
	    IList<IMusicRecording> Tracks { get; }
	}
}