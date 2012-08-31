using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Transhipment;

namespace Tests
{
    [TestClass]
    public class MovieTest
    {
        [TestMethod]
        public void MovieBasicSerializationTest()
        {
            var thing = SchemaFactory.Create(Schema.Movie);
            var str = thing.Stringify();

            var newThing = SchemaFactory.Parse(str);
            Assert.IsNotNull(newThing);
        }
    }
}