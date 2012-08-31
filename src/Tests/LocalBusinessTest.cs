using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Transhipment;

namespace Tests
{
    [TestClass]
    public class LocalBusinessTest
    {
        [TestMethod]
        public void LocalBusinessBasicSerializationTest()
        {
            var thing = SchemaFactory.Create(Schema.LocalBusiness);
            var str = thing.Stringify();

            var newThing = SchemaFactory.Parse(str);
            Assert.IsNotNull(newThing);
        }
    }
}