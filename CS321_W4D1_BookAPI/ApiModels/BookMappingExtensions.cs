using CS321_W4D1_BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CS321_W4D1_BookAPI.ApiModels
{
    public static class BookMappingExtenstions
    {

        public static BookModel ToApiModel(this Book book)  // if confused change arbitrary to "needstobeconverted")
        {

            // return a new BookModel and copy the
            // property values over from the Book
            // TODO: map the Book domain object to a BookModel
            return new BookModel
            {

                Id = book.Id,     // left side is book model, right is parameter thats passing
                Title = book.Title,
                Genre = book.Genre,
                OriginalLanguage = book.OriginalLanguage,
                PublicationYear = book.PublicationYear,
               
                AuthorId = book.AuthorId,
                // concatenate the author's name properties and use it as the value of
                // Author. Use null if the Author is null.
                Author = book.Author != null
                     ? book.Author.FirstName + ", " + book.Author.LastName
                     : null,


        
                    PublisherId =book.PublisherId, // not working
                    Publisher= book.Publisher != null ? book.Publisher.Name + ", " + book.Publisher.HeadQuartersLocation : "NA"
            };
        }

        public static Book ToDomainModel(this BookModel bookModel)
        {
            // return a new Book domain object and copy the
            // property values over from the BookModel

            // TODO: map the BookModel to a Book domain object
            return new Book
            {

                Id = bookModel.Id,
                Title = bookModel.Title,
                Genre = bookModel.Genre,
                OriginalLanguage = bookModel.OriginalLanguage,
                PublicationYear = bookModel.PublicationYear,
                PublisherId = bookModel.PublisherId,
                AuthorId = bookModel.AuthorId,
                // Note that we don't set the Publisher or Author object properties. 
                // Setting the PublisherId and AuthorId fields is enough.
            };
        }

        public static IEnumerable<BookModel> ToApiModels(this IEnumerable<Book> authors)
        {
            return authors.Select(a => a.ToApiModel());
        }

        public static IEnumerable<Book> ToDomainModels(this IEnumerable<BookModel> authorModels)
        {
            return authorModels.Select(a => a.ToDomainModel());
        }
    }
}
