using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Transhipment;

namespace Tests
{
	[TestClass]
	public class ThingTest
	{
        [TestMethod]
        public void ThingBasicSerializationTest()
        {
            var thing = SchemaFactory.Create(Schema.Thing);
            var str = thing.Stringify();

            var newThing = SchemaFactory.Parse(str);
            Assert.IsNotNull(newThing);
        }
    }
}
