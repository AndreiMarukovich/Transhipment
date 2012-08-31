using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Transhipment;

namespace Tests
{
    [TestClass]
    public class UserInteractionTest
    {
        [TestMethod]
        public void UserInteractionConvertTest()
        {
            var data = DateTimeOffset.UtcNow;
            var userInteraction = new UserInteraction
                                      {
                                          CommentText = "Comment",
                                          CommentTime = data,
                                          InteractionType = UserInteractionType.Comments,
                                          Description = "Description",
                                          ReplyToUrl = "http://url"
                                      };

            var json = userInteraction.ToJson();
            var testObject = UserInteraction.FromJson(json);
            
            Assert.AreEqual("Comment", testObject.CommentText);
            Assert.AreEqual("http://url", testObject.ReplyToUrl);
            Assert.AreEqual("Description", testObject.Description);
            Assert.AreEqual(UserInteractionType.Comments, testObject.InteractionType);
            Assert.AreEqual(data, testObject.CommentTime);
        }
    }
}