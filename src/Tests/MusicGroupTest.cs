using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Transhipment;

namespace Tests
{
    [TestClass]
    public class MusicGroupTest
    {
        [TestMethod]
        public void MusicGroupBasicSerializationTest()
        {
            var thing = SchemaFactory.Create(Schema.MusicGroup);
            var str = thing.Stringify();

            var newThing = SchemaFactory.Parse(str);
            Assert.IsNotNull(newThing);
        }
    }
}