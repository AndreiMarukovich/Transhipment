using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Transhipment;

namespace Tests
{
    [TestClass]
    public class ArticleTest
    {
        [TestMethod]
        public void ArticleBasicSerializationTest()
        {
            var thing = SchemaFactory.Create(Schema.Article);
            var str = thing.Stringify();

            var newThing = SchemaFactory.Parse(str);
            Assert.IsNotNull(newThing);
        }
    }
}