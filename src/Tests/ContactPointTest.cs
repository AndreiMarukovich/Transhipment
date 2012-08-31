using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Transhipment;

namespace Tests
{
    [TestClass]
    public class ContactPointTest
    {
        [TestMethod]
        public void ContactPointBasicSerializationTest()
        {
            var thing = SchemaFactory.Create(Schema.ContactPoint);
            var str = thing.Stringify();

            var newThing = SchemaFactory.Parse(str);
            Assert.IsNotNull(newThing);
        }
    }
}