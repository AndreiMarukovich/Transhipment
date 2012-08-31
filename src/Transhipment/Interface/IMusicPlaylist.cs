using System.Collections.Generic;

namespace Transhipment
{
	public interface IMusicPlaylist : ICreativeWork
	{
        /// <summary>
        /// The number of tracks in this album or playlist.
        /// </summary>
        int NumTracks { get; set; }
        /// <summary>
        /// Music recording (track) — usually a single song
        /// </summary>
        IList<IMusicRecording> Tracks { get; }
	}
}