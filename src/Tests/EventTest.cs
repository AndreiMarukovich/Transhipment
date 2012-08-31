using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Transhipment;

namespace Tests
{
    [TestClass]
    public class EventTest
    {
        [TestMethod]
        public void EventBasicSerializationTest()
        {
            var thing = SchemaFactory.Create(Schema.Event);
            var str = thing.Stringify();

            var newThing = SchemaFactory.Parse(str);
            Assert.IsNotNull(newThing);
        }
    }
}