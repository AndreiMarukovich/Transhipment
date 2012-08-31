using System.Collections.Generic;
using Transhipment.Helpers;
using Windows.Data.Json;

namespace Transhipment.Implementation
{
    class MusicAlbum : MusicPlaylist, IMusicAlbum
    {
        public override string Type
        {
            get { return Schema.MusicAlbum; }
        }

        public IList<IMusicGroup> ByArtist { get; private set; }

        public MusicAlbum()
        {
            ByArtist = new List<IMusicGroup>();
        }

        internal override JsonObject ToJson(out JsonObject properties)
        {
            var json = base.ToJson(out properties);
            ThingHelper.AddAsObjectArray(ByArtist, "byArtist", properties);
            return json;
        }

        internal override JsonObject PopulateFromJson(JsonObject jsonObject)
        {
            var properties = base.PopulateFromJson(jsonObject);
            if (properties == null)
                return null;

            ByArtist = ThingHelper.GetObjectArray<IMusicGroup>(properties, "byArtist");
            return properties;
        }
    }
}