using AutoMapper;
using BookStoreApi.BookOperations.CreateBooks;
using BookStoreApi.BookOperations.DeleteBook;
using BookStoreApi.BookOperations.GetBookDetail;
using BookStoreApi.BookOperations.GetBooks;
using BookStoreApi.BookOperations.UpdateBook;
using BookStoreApi.DBOperations;
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
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Get method for read all book
        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context,_mapper);
            var result = query.Handle();
            return Ok(result);
        }

        //Get method for read single book by id
        [HttpGet("{id}")]//api/books/1
        public IActionResult GetById(int id)
        {
            BookDetailViewModel result;
            try
            {
                GetBookDetailQuery query = new GetBookDetailQuery(_context,_mapper);
                query.BookId = id;
                result = query.Handle();
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
            return Ok(result);
            
        }


        //Post method for create new book
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context,_mapper);
            try
            {
                command.Model = newBook;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        
            return Ok();
        }

        //Put method for update a book
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdatedBookModel updatedBook)
        {
            try
            {
                UpdateBookCommand command = new UpdateBookCommand(_context, _mapper);
                command.BookId = id;
                command.Model = updatedBook;
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
            return Ok();
        }

        //Delete method dor delete a book
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId = id;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            return Ok();
        }
        
    }
}
