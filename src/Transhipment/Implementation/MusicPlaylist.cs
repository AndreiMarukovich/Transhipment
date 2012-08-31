using System.Collections.Generic;
using Transhipment.Helpers;
using Windows.Data.Json;

namespace Transhipment.Implementation
{
    class MusicPlaylist : CreativeWork, IMusicPlaylist
    {
        public override string Type
        {
            get { return Schema.MusicPlaylist; }
        }

        public int NumTracks { get; set; }
        public IList<IMusicRecording> Tracks { get; private set; }

        public MusicPlaylist()
        {
            Tracks = new List<IMusicRecording>();
        }

        internal override JsonObject ToJson(out JsonObject properties)
        {
            var json = base.ToJson(out properties);

            properties.Add("numTracks", JsonValue.CreateNumberValue(NumTracks));
            ThingHelper.AddAsObjectArray(Tracks, "tracks", properties);

            return json;
        }

        internal override JsonObject PopulateFromJson(JsonObject jsonObject)
        {
            var properties = base.PopulateFromJson(jsonObject);
            if (properties == null)
                return null;

            IJsonValue value;
            if (properties.TryGetValue("numTracks", out value))
                NumTracks = (int)value.GetNumber();

            Tracks = ThingHelper.GetObjectArray<IMusicRecording>(properties, "tracks");

            return properties;
        }
         
    }
}