using System.Collections.Generic;
using Transhipment.Helpers;
using Windows.Data.Json;

namespace Transhipment.Implementation
{
    class MusicRecording : CreativeWork, IMusicRecording
    {
        public override string Type
        {
            get { return Schema.MusicRecording; }
        }

        public IList<IMusicGroup> ByArtist { get; private set; }
        public int Duration { get; set; }
        public IList<IMusicAlbum> InAlbum { get; private set; }
        public IList<IMusicPlaylist> InPlaylist { get; private set; }

        public MusicRecording()
        {
            ByArtist = new List<IMusicGroup>();
            InAlbum = new List<IMusicAlbum>();
            InPlaylist = new List<IMusicPlaylist>();
        }

        internal override JsonObject ToJson(out JsonObject properties)
        {
            var json = base.ToJson(out properties);

            properties.Add("duration", JsonValue.CreateNumberValue(Duration));
            ThingHelper.AddAsObjectArray(ByArtist, "byArtist", properties);
            ThingHelper.AddAsObjectArray(InAlbum, "inAlbum", properties);
            ThingHelper.AddAsObjectArray(InPlaylist, "inPlaylist", properties);

            return json;
        }

        internal override JsonObject PopulateFromJson(JsonObject jsonObject)
        {
            var properties = base.PopulateFromJson(jsonObject);
            if (properties == null)
                return null;

            IJsonValue value;
            if (properties.TryGetValue("duration", out value))
                Duration = (int)value.GetNumber();

            ByArtist = ThingHelper.GetObjectArray<IMusicGroup>(properties, "byArtist");
            InAlbum = ThingHelper.GetObjectArray<IMusicAlbum>(properties, "inAlbum");
            InPlaylist = ThingHelper.GetObjectArray<IMusicPlaylist>(properties, "inPlaylist");

            return properties;
        }
    }
}