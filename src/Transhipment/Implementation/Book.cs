using System;
using System.Collections.Generic;
using Transhipment.Helpers;
using Windows.Data.Json;

namespace Transhipment.Implementation
{
    class Book : CreativeWork, IBook
    {
        private const string EBookFormat = "http://schema.org/EBook";
        private const string HardcoverFormat = "http://schema.org/Hardcover";
        private const string PaperbackFormat = "http://schema.org/Paperback";

        public override string Type
        {
            get { return Schema.Book; }
        }

        public string BookEdition { get; set; }
        public BookFormatType BookFormat { get; set; }
        public IList<IPerson> Illustrator { get; private set; }
        public string ISBN { get; set; }
        public int NumberOfPages { get; set; }

        public Book()
        {
            Illustrator = new List<IPerson>();
        }

        internal override JsonObject ToJson(out JsonObject properties)
        {
            var json = base.ToJson(out properties);

            properties.Add("bookEdition", JsonValue.CreateStringValue(BookEdition ?? String.Empty));
            properties.Add("isbn", JsonValue.CreateStringValue(ISBN ?? String.Empty));
            properties.Add("numberOfPages", JsonValue.CreateNumberValue(NumberOfPages));

            ThingHelper.AddAsObjectArray(Illustrator, "illustrator", properties);

            var bookFormat = String.Empty;
            switch (BookFormat)
            {
                case BookFormatType.None:
                    bookFormat = String.Empty;
                    break;
                case BookFormatType.EBook:
                    bookFormat = EBookFormat;
                    break;
                case BookFormatType.Hardcover:
                    bookFormat = HardcoverFormat;
                    break;
                case BookFormatType.Paperback:
                    bookFormat = PaperbackFormat;
                    break;
            }
            properties.Add("bookFormat", JsonValue.CreateStringValue(bookFormat ?? String.Empty));

            return json;
        }

        internal override JsonObject PopulateFromJson(JsonObject jsonObject)
        {
            var properties = base.PopulateFromJson(jsonObject);
            if (properties == null)
                return null;

            IJsonValue value;
            if (properties.TryGetValue("bookEdition", out value))
                BookEdition = value.GetString();
            if (properties.TryGetValue("isbn", out value))
                ISBN = value.GetString();
            if (properties.TryGetValue("numberOfPages", out value))
                NumberOfPages = (int)value.GetNumber();

            Illustrator = ThingHelper.GetObjectArray<IPerson>(properties, "illustrator");

            if (properties.TryGetValue("bookFormat", out value))
            {
                var format = value.GetString();
                switch (format)
                {
                    case EBookFormat:
                        BookFormat = BookFormatType.EBook;
                        break;
                    case HardcoverFormat:
                        BookFormat = BookFormatType.Hardcover;
                        break;
                    case PaperbackFormat:
                        BookFormat = BookFormatType.Paperback;
                        break;
                    default:
                        BookFormat = BookFormatType.None;
                        break;
                }
            }

            return properties;
        }
    }
}