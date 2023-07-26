using BookStoreApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace BookStoreApi.DBOperations
{
    public class DataGenerator
    {
       
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
                context.Books.AddRange(
                    new Book
                    {
                       // Id = 1,
                        Title = "Lean Startup",
                        AuthorId = 1,
                        GenreId = 1,
                        PageCount = 200,
                        PublishDate = new DateTime(2011, 06, 12)
                    },
                     new Book
                     {
                        // Id = 2,
                         Title = "The Alchemist",
                         AuthorId = 2, //Paulo Coelho
                         GenreId = 2, // Fiction
                         PageCount = 208,
                         PublishDate = new DateTime(1988, 04, 25)
                     },
                     new Book
                     {
                        // Id = 3,
                         Title = "Harry Potter and the Sorcerer's Stone",
                         AuthorId = 3, //J.K. Rowling
                         GenreId = 3, // Fantasy
                         PageCount = 320,
                         PublishDate = new DateTime(1997, 06, 26)
                     },
                      new Book
                      {
                         // Id = 4,
                          Title = "To Kill a Mockingbird",
                          AuthorId = 4,//Harper Lee
                          GenreId = 4,// Classic
                          PageCount = 336,
                          PublishDate = new DateTime(1960, 07, 11)
                      },
                      new Book
                      {
                        //  Id = 5,
                          Title = "1984",
                          AuthorId = 5, //George Orwell
                          GenreId = 5, // Dystopian
                          PageCount = 328,
                          PublishDate = new DateTime(1949, 06, 08)
                      },
                      new Book
                      {
                        //  Id = 6,
                          Title = "The Great Gatsby",
                          AuthorId = 6, //F. Scott Fitzgerald
                          GenreId = 4, // Classic
                          PageCount = 180,
                          PublishDate = new DateTime(1925, 04, 10)
                      });

                context.SaveChanges();


            }
        }
    }
}
