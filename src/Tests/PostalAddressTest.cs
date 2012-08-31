using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Transhipment;

namespace Tests
{
    [TestClass]
    public class PostalAddressTest
    {
        [TestMethod]
        public void PostalAddressBasicSerializationTest()
        {
            var thing = SchemaFactory.Create(Schema.PostalAddress);
            var str = thing.Stringify();

            var newThing = SchemaFactory.Parse(str);
            Assert.IsNotNull(newThing);
        }
         
    }
}