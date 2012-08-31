using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Transhipment;

namespace Tests
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void ProductBasicSerializationTest()
        {
            var thing = SchemaFactory.Create(Schema.Product);
            var str = thing.Stringify();

            var newThing = SchemaFactory.Parse(str);
            Assert.IsNotNull(newThing);
        }
    }
}