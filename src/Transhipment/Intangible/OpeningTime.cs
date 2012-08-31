using System;

namespace Transhipment
{
    public enum Day
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
    }

    public sealed class OpeningHours
    {
        public Day DayOfWeek { get; set; }
        public int OpeningHour { get; set; }
        public int OpeningMinute { get; set; }
        public int ClosingHour { get; set; }
        public int ClosingMinute { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1}:{2}-{3}:{4}", 
                DayOfWeek.ToString().Substring(0,2),
                OpeningHour, OpeningMinute,
                ClosingHour, ClosingMinute);
        }

        public static OpeningHours FromString(string valueStr)
        {
            if (String.IsNullOrWhiteSpace(valueStr))
                return null;

            var parts = valueStr.Split(new[] { ' ', ':', '-' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 5)
                return null;

            var newObject = new OpeningHours();
            try
            {
                newObject.OpeningHour = Convert.ToInt32(parts[1]);
                newObject.OpeningMinute = Convert.ToInt32(parts[2]);
                newObject.ClosingHour = Convert.ToInt32(parts[3]);
                newObject.ClosingMinute = Convert.ToInt32(parts[4]);

                switch (parts[0])
                {
                    case "Su":
                        newObject.DayOfWeek = Day.Sunday;
                        break;
                    case "Mo":
                        newObject.DayOfWeek = Day.Monday;
                        break;
                    case "Tu":
                        newObject.DayOfWeek = Day.Tuesday;
                        break;
                    case "We":
                        newObject.DayOfWeek = Day.Wednesday;
                        break;
                    case "Th":
                        newObject.DayOfWeek = Day.Thursday;
                        break;
                    case "Fr":
                        newObject.DayOfWeek = Day.Friday;
                        break;
                    case "Sa":
                        newObject.DayOfWeek = Day.Saturday;
                        break;
                    default:
                        return null;
                }
            }
            catch
            {
                return null;
            }

            return newObject;
        }

    }
}