using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Transhipment;

namespace Tests
{
    [TestClass]
    public class OpeningHoursTest
    {
        [TestMethod]
        public void OpeningHoursBasicTest()
        {
            var time = new OpeningHours
                           {
                               DayOfWeek = Day.Wednesday,
                               OpeningHour = 15,
                               OpeningMinute = 45,
                               ClosingHour = 23,
                               ClosingMinute = 30
                           };

            var str = time.ToString();
            var newTime = OpeningHours.FromString(str);

            Assert.IsNotNull(newTime);
            Assert.AreEqual(Day.Wednesday, newTime.DayOfWeek);
            Assert.AreEqual(15, newTime.OpeningHour);
            Assert.AreEqual(45, newTime.OpeningMinute);
            Assert.AreEqual(23, newTime.ClosingHour);
            Assert.AreEqual(30, newTime.ClosingMinute);

        }
    }
}