using BookStoreApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class BookController : ControllerBase
    {
        //Example static data

        //For Author 
        private static List<Author> AuthorList = new List<Author>()
        {
            new Author { Id = 1, Name = "Eric Ries" },
            new Author { Id = 2, Name = "Paulo Coelho" },
            new Author { Id = 3, Name = "J.K. Rowling" },
            new Author { Id = 4, Name = "Harper Lee" },
            new Author { Id = 5, Name = "George Orwell" },
            new Author { Id = 6, Name = "F. Scott Fitzgerald" }
        };

        //For Genre
        private static List<Genre> GenreList = new List<Genre>()
        {
            new Genre{Id = 1, Name =  "Personal Growth" },
            new Genre{Id = 2, Name =  "Fiction" },
            new Genre{Id = 3, Name =  "Fantasy" },
            new Genre{Id = 4, Name =  "Classic" },
            new Genre{Id = 5, Name =  "Dystopian" }
        };

        //For Book List
        private static List<Book> BookList = new List<Book>()
        {
            new Book
            {
                Id = 1, 
                Title = "Lean Startup",
                AuthorId = 1, //Eric Ries
                GenreId = 1, // Personal Growth
                PageCount = 200, 
                PublishDate = new DateTime(2011,06,12)
            },
            new Book 
            {
                Id = 2,
                Title = "The Alchemist",
                AuthorId = 2, //Paulo Coelho
                GenreId = 2, // Fiction
                PageCount = 208,
                PublishDate = new DateTime(1988, 04, 25)
            },
            new Book
            {
                 Id = 3,
                 Title = "Harry Potter and the Sorcerer's Stone",
                 AuthorId = 3, //J.K. Rowling
                 GenreId = 3, // Fantasy
                 PageCount = 320,
                 PublishDate = new DateTime(1997, 06, 26)
            },
            new Book
            {
                Id = 4,
                Title = "To Kill a Mockingbird",
                AuthorId = 4,//Harper Lee
                GenreId = 4,// Classic
                PageCount = 336,
                PublishDate = new DateTime(1960, 07, 11)
            },
            new Book
            {
                Id = 5,
                Title = "1984",
                AuthorId = 5, //George Orwell
                GenreId = 5, // Dystopian
                PageCount = 328,
                PublishDate = new DateTime(1949, 06, 08)
            },
            new Book
            {
                Id = 6,
                Title = "The Great Gatsby",
                AuthorId = 6, //F. Scott Fitzgerald
                GenreId = 4, // Classic
                PageCount = 180,
                PublishDate = new DateTime(1925, 04, 10)
            }
        };

        //Get method for read all book
        [HttpGet]
        public List<Book> GetBooks()
        {
            var bookList = BookList.OrderBy(x => x.Id).ToList<Book>();//LinQ

            return bookList;
        }

        //Get method for read single book by id
        [HttpGet("{id}")]//api/books/1
        public Book GetById(int id)
        {
            var book = BookList.Where(x => x.Id == id).SingleOrDefault();

            return book;
        }


        //Post method for create new book
        [HttpPost]
        public IActionResult AddBook([FromBody] Book newBook)
        {
            var book = BookList.SingleOrDefault(x => x.Title == newBook.Title);
            if (book is not null)
            {
                return BadRequest();
            }
           
            BookList.Add(newBook);
            return Ok();
        }

        //Put method for update a book
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var book = BookList.SingleOrDefault(x => x.Id == id);
            if (book is null)
            {
                return BadRequest();
            }

            book.GenreId = updatedBook.GenreId != default ? updatedBook.GenreId : book.GenreId;
            book.AuthorId = updatedBook.AuthorId != default ? updatedBook.AuthorId : book.AuthorId;
            book.PageCount = updatedBook.PageCount != default ? updatedBook.PageCount : book.PageCount;
            book.PublishDate = updatedBook.PublishDate != default ? updatedBook.PublishDate : book.PublishDate;
            book.Title = updatedBook.Title != default ? updatedBook.Title: book.Title;

            return Ok();
        }

        //Delete method dor delete a book
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = BookList.SingleOrDefault(x => x.Id == id);
            if (book is null)
            {
                return BadRequest();
            }

            BookList.Remove(book);

            return Ok();
        }
        
    }
}
