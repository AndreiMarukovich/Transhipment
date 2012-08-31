using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Transhipment;

namespace Tests
{
    [TestClass]
    public class MusicAlbumTest
    {
        [TestMethod]
        public void MusicAlbumBasicSerializationTest()
        {
            var thing = SchemaFactory.Create(Schema.MusicAlbum);
            var str = thing.Stringify();

            var newThing = SchemaFactory.Parse(str);
            Assert.IsNotNull(newThing);
        }
    }
}