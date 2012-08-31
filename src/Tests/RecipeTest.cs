using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Transhipment;

namespace Tests
{
    [TestClass]
    public class RecipeTest
    {
        [TestMethod]
        public void RecipeBasicSerializationTest()
        {
            var thing = SchemaFactory.Create(Schema.Recipe);
            var str = thing.Stringify();

            var newThing = SchemaFactory.Parse(str);
            Assert.IsNotNull(newThing);
        }
    }
}