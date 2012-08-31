using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Transhipment;

namespace Tests
{
    [TestClass]
    public class GeoCoordinatesTest
    {
        [TestMethod]
        public void GeoCoordinatesBasicSerializationTest()
        {
            var thing = SchemaFactory.Create(Schema.GeoCoordinates);
            var str = thing.Stringify();

            var newThing = SchemaFactory.Parse(str);
            Assert.IsNotNull(newThing);
        }
    }
}