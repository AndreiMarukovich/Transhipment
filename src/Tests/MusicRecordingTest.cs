using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Transhipment;

namespace Tests
{
    [TestClass]
    public class MusicRecordingTest
    {
        [TestMethod]
        public void MusicRecordingBasicSerializationTest()
        {
            var thing = SchemaFactory.Create(Schema.MusicRecording);
            var str = thing.Stringify();

            var newThing = SchemaFactory.Parse(str);
            Assert.IsNotNull(newThing);
        }
    }
}