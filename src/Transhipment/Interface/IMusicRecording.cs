using System.Collections.Generic;

namespace Transhipment
{
	public interface IMusicRecording : ICreativeWork
	{
        IList<IMusicGroup> ByArtist { get; }
        /// <summary>
        /// The duration of the item, in minutes
        /// </summary>
        int Duration { get; set; }
        /// <summary>
        /// The album to which this recording belongs.
        /// </summary>
        IList<IMusicAlbum> InAlbum { get; }
        /// <summary>
        /// The playlist to which this recording belongs.
        /// </summary>
	    IList<IMusicPlaylist> InPlaylist { get; }
	}
}