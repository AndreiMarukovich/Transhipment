using System.Collections.Generic;

namespace Transhipment
{
	public interface IBook : ICreativeWork
	{
        string BookEdition { get; set; }
        BookFormatType BookFormat { get; set; }
        IList<IPerson> Illustrator { get; }
        string ISBN { get; set; }
        int NumberOfPages { get; set; }
	}

    public enum BookFormatType
    {
        None,
        EBook,
        Hardcover,
        Paperback
    }
}