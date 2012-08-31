using System;
using System.Collections.Generic;
using Transhipment.Helpers;
using Windows.Data.Json;

namespace Transhipment
{
    public enum UserInteractionType { Blocks , Checkins, Comments, Downloads, Likes, PageVisits, Plays, PlusOnes, Tweets}

	public sealed class UserInteraction
	{
        private static readonly List<string> Formats = new List<string>
            {
                "http://schema.org/UserBlocks", 
                "http://schema.org/UserCheckins",
                "http://schema.org/UserComments",
                "http://schema.org/UserDownloads",
                "http://schema.org/UserLikes",
                "http://schema.org/UserPageVisits",
                "http://schema.org/UserPlays",
                "http://schema.org/UserPlusOnes",
                "http://schema.org/UserTweets",
            };

	    public UserInteractionType InteractionType { get; set; }
        public string Description { get; set; }
        public string CommentText { get; set; }
        public DateTimeOffset? CommentTime { get; set; }
        public IPerson Creator { get; set; }
        /// <summary>
        /// The URL at which a reply may be posted to the specified UserComment.
        /// </summary>
        public string ReplyToUrl { get; set; }

        public JsonObject ToJson()
        {
            var json = new JsonObject { { "type", JsonValue.CreateStringValue(Formats[(int)InteractionType]) } };
            var properties = new JsonObject
                                 {
                                     {"description", JsonValue.CreateStringValue(Description ?? String.Empty)},
                                     {"commentText", JsonValue.CreateStringValue(CommentText ?? String.Empty)},
                                     {"commentTime", JsonValue.CreateStringValue(DateTimeHelper.ToString(CommentTime))},
                                     {"replyToUrl", JsonValue.CreateStringValue(ReplyToUrl ?? String.Empty)},
                                 };

            ThingHelper.AddAsObject(Creator, "creator", properties);
            json.Add("properties", properties);

            return json;
        }

        public static UserInteraction FromJson(JsonObject jsonObject)
        {
            IJsonValue value;
            if (!jsonObject.TryGetValue("type", out value))
                return null;

            var userInteraction = new UserInteraction();
            var index = Formats.IndexOf(value.GetString());
            if (index != -1)
                userInteraction.InteractionType = (UserInteractionType)index;

            if (!jsonObject.TryGetValue("properties", out value))
                return null;

            var properties = value.GetObject();
            if (properties == null)
                return null;

            if (properties.TryGetValue("description", out value))
                userInteraction.Description = value.GetString();
            if (properties.TryGetValue("commentText", out value))
                userInteraction.CommentText = value.GetString();
            if (properties.TryGetValue("commentTime", out value))
                userInteraction.CommentTime = DateTimeHelper.FromString(value.GetString());
            if (properties.TryGetValue("replyToUrl", out value))
                userInteraction.ReplyToUrl = value.GetString();
            if (properties.TryGetValue("creator", out value))
                userInteraction.Creator = SchemaFactory.Parse(value.GetObject()) as IPerson;

            return userInteraction;
        }
	}
}