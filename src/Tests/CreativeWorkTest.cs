using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Transhipment;

namespace Tests
{
    [TestClass]
    public class CreativeWorkTest
    {
        [TestMethod]
        public void CreativeWorkBasicSerializationTest()
        {
            var thing = SchemaFactory.Create(Schema.CreativeWork);
            var str = thing.Stringify();

            var newThing = SchemaFactory.Parse(str);
            Assert.IsNotNull(newThing);
        }
    }
}