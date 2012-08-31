using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Transhipment;

namespace Tests
{
    [TestClass]
    public class PlaceTest
    {
        [TestMethod]
        public void PlaceBasicSerializationTest()
        {
            var thing = SchemaFactory.Create(Schema.Place);
            var str = thing.Stringify();

            var newThing = SchemaFactory.Parse(str);
            Assert.IsNotNull(newThing);
        }
    }
}