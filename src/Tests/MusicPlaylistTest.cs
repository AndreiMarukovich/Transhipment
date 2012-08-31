using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Transhipment;

namespace Tests
{
    [TestClass]
    public class MusicPlaylistTest
    {
        [TestMethod]
        public void MusicPlaylistBasicSerializationTest()
        {
            var thing = SchemaFactory.Create(Schema.MusicPlaylist);
            var str = thing.Stringify();

            var newThing = SchemaFactory.Parse(str);
            Assert.IsNotNull(newThing);
        }
         
    }
}