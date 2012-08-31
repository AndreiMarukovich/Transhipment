using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Transhipment;

namespace Tests
{
    [TestClass]
    public class OrganizationTest
    {
        [TestMethod]
        public void OrganizationBasicSerializationTest()
        {
            var thing = SchemaFactory.Create(Schema.Organization);
            var str = thing.Stringify();

            var newThing = SchemaFactory.Parse(str);
            Assert.IsNotNull(newThing);
        }
    }
}