using System;
using System.Collections.Generic;

namespace Transhipment.Implementation
{
    static class SchemaImplementations
    {
        private static readonly Dictionary<string, Type> _implementations = new Dictionary<string, Type>
        {
            {Schema.Thing, typeof(Thing)},
				{Schema.ContactPoint, typeof(ContactPoint)},
				{Schema.PostalAddress, typeof(PostalAddress)},
				{Schema.GeoCoordinates, typeof(GeoCoordinates)},
				{Schema.CreativeWork, typeof(CreativeWork)},
				{Schema.Article, typeof(Article)},
				{Schema.Book, typeof(Book)},
				{Schema.Event, typeof(Event)},
				{Schema.Organization, typeof(Organization)},
				{Schema.LocalBusiness, typeof(LocalBusiness)},
				{Schema.Movie, typeof(Movie)},
				{Schema.MusicAlbum, typeof(MusicAlbum)},
				{Schema.MusicPlaylist, typeof(MusicPlaylist)},
				{Schema.MusicGroup, typeof(MusicGroup)},
				{Schema.MusicRecording, typeof(MusicRecording)},
				{Schema.Product, typeof(Product)},
				{Schema.Person, typeof(Person)},
				{Schema.Place, typeof(Place)},
				{Schema.Recipe, typeof(Recipe)},
        };

        public static Dictionary<string, Type> Implementations { get { return _implementations; } }
    }
}
