using System.Collections.Generic;
using Transhipment.Helpers;
using Windows.Data.Json;

namespace Transhipment.Implementation
{
    class MusicGroup : Organization, IMusicGroup
    {
        public override string Type
        {
            get { return Schema.MusicGroup; }
        }

        public IList<IMusicAlbum> Albums { get; private set; }
        public IList<IPerson> MusicGroupMember { get; private set; }
        public IList<IMusicRecording> Tracks { get; private set; }

        public MusicGroup()
        {
            Albums = new List<IMusicAlbum>();
            MusicGroupMember = new List<IPerson>();
            Tracks = new List<IMusicRecording>();
        }

        internal override JsonObject ToJson(out JsonObject properties)
        {
            var json = base.ToJson(out properties);
            
            ThingHelper.AddAsObjectArray(Albums, "albums", properties);
            ThingHelper.AddAsObjectArray(MusicGroupMember, "musicGroupMember", properties);
            ThingHelper.AddAsObjectArray(Tracks, "tracks", properties);

            return json;
        }

        internal override JsonObject PopulateFromJson(JsonObject jsonObject)
        {
            var properties = base.PopulateFromJson(jsonObject);
            if (properties == null)
                return null;

            Albums = ThingHelper.GetObjectArray<IMusicAlbum>(properties, "albums");
            MusicGroupMember = ThingHelper.GetObjectArray<IPerson>(properties, "musicGroupMember");
            Tracks = ThingHelper.GetObjectArray<IMusicRecording>(properties, "tracks");
            return properties;
        }
    }
}