using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Transhipment;

namespace Tests
{
    [TestClass]
    public class BookTest
    {
        [TestMethod]
        public void BookBasicSerializationTest()
        {
            var book = SchemaFactory.Create(Schema.Book);
            var str = book.Stringify();

            var newBook = SchemaFactory.Parse(str);
            Assert.IsNotNull(newBook);
        }
    }
}