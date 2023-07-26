using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch; //for patch
using QuoteApi.Entities;
using QuoteApi.DbOperations;
using QuoteApi.Services;
using Microsoft.AspNetCore.Authorization;

namespace QuoteApi.Controllers
{
 

    [Route("api/[controller]s")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        internal readonly QuoteDbContext _context; //I change the private to internal for the access process on the extensions but ı am not sure is it true??

        public QuoteController(QuoteDbContext context)
        {
            _context = context;
        }
        /* I tried to fake authorization but ı couldn't set the program.cs
         * 
        // This action requires the user to be logged in
        [HttpGet]
        [Authorize(Policy = "FakeAuthorizationPolicy")]
        public IActionResult Get()
        {
            // Your logic here
            return Ok("This is a protected endpoint.");
        }
        */

        //Get
        [HttpGet]
        public List<Quote> GetAll() {
            var quotes = _context.Quotes.OrderBy(x => x.Id).ToList<Quote>(); //Linq
            
            return quotes;
           
        }
        //GetById
        [HttpGet("{id}")]
        public Quote GetById(int id)
        {
            var quote = _context.Quotes.Where(x => x.Id == id).SingleOrDefault();
           
            return quote;
        }
        //Post
        [HttpPost]
        public IActionResult AddQuote([FromBody] Quote newQuote)
        {
            var quote = _context.Quotes.SingleOrDefault(x=> x.Text == newQuote.Text);
            if (quote is not null)
            {
                return BadRequest();
            }
            _context.Quotes.Add(newQuote);
            _context.SaveChanges();
            return Ok();
        }
        //Put
        [HttpPut("{id}")]
        public IActionResult UpdateQuote(int id, [FromBody] Quote updatedQuote) {
            var quote = _context.Quotes.SingleOrDefault(x=> x.Id==id);
            if(quote is null)
            {
                return BadRequest();
            }
            quote.Text = updatedQuote.Text == default ? quote.Text : updatedQuote.Text;
            quote.Author = updatedQuote.Author == default ? quote.Author : updatedQuote.Author;
           
            _context.SaveChanges();
            return Ok();
        }
        //Delete
        [HttpDelete("{id}")]
        public IActionResult DeleteQuote(int id)
        {
            var quote = _context.Quotes.SingleOrDefault(x=> x.Id==id);
            if (quote is null)
            {
                return BadRequest();
            }

            _context.Quotes.Remove(quote);
            _context.SaveChanges();
            return Ok();
        }

        // Patch
        [HttpPatch("{id}")]
        public IActionResult PatchQuote(int id, [FromBody] JsonPatchDocument<Quote> patchDoc)
        {
            var quote = _context.Quotes.SingleOrDefault(x => x.Id == id);
            if (quote is null)
            {
                return BadRequest();
            }

            patchDoc.ApplyTo(quote, ModelState);

            if (!TryValidateModel(quote))
            {
                return BadRequest(ModelState);
            }

            _context.SaveChanges();
            return Ok();
        }

        // Get a random quote
        [HttpGet("random")]
        public Quote GetRandomQuote()
        {
            var count = _context.Quotes.Count();
            var random = new Random();
            var randomId = random.Next(1, count + 1);
            var quote = _context.Quotes.FirstOrDefault(x => x.Id == randomId);

            return quote;
        }


        // Get quotes by author
        [HttpGet("byauthor/{author}")]
        public List<Quote> GetQuotesByAuthor(string author)
        {
            var quotes = _context.Quotes.Where(x => x.Author.ToLower() == author.ToLower()).ToList();//linq
   
            return quotes;
        }

    }
}
