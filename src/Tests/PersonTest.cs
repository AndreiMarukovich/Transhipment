using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Transhipment;

namespace Tests
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void PersonBasicSerializationTest()
        {
            var thing = SchemaFactory.Create(Schema.Person);
            var str = thing.Stringify();

            var newThing = SchemaFactory.Parse(str);
            Assert.IsNotNull(newThing);
        }
    }
}