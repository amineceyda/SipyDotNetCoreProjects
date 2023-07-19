using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch; //for patch

namespace QuoteApi.Controllers
{
    public class Quote
    {
        public int Id { get; set; }
        public string? Author { get; set; }
        public string? Text { get; set; }
    }

    [Route("api/[controller]s")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        //Sample data 
        private readonly List<Quote> quotes = new List<Quote>
        {
            new Quote { Id = 1, Author = "Albert Einstein", Text = "Imagination is more important than knowledge." },
            new Quote { Id = 2, Author = "Nelson Mandela", Text = "The greatest glory in living lies not in never falling, but in rising every time we fall." },
            new Quote { Id = 3, Author = "Maya Angelou", Text = "You may not control all the events that happen to you, but you can decide not to be reduced by them." },
            new Quote { Id = 4, Author = "Steve Jobs", Text = "Your time is limited, don't waste it living someone else's life." },
            new Quote { Id = 5, Author = "Eleanor Roosevelt", Text = "The future belongs to those who believe in the beauty of their dreams." },
            new Quote { Id = 6, Author = "Walt Disney", Text = "All our dreams can come true, if we have the courage to pursue them." },
            new Quote { Id = 7, Author = "Confucius", Text = "It does not matter how slowly you go as long as you do not stop." },
            new Quote { Id = 8, Author = "Thomas Edison", Text = "I have not failed. I've just found 10,000 ways that won't work." },
            new Quote { Id = 9, Author = "Oprah Winfrey", Text = "Turn your wounds into wisdom." },
            new Quote { Id = 10, Author = "Mark Twain", Text = "The secret of getting ahead is getting started." }
        };

        //For read all quotes
        [HttpGet]
        public ActionResult<IEnumerable<Quote>> GetAllQuotes()
        {
            return quotes;
        }

        //For read single quote // from router body etc. api/quote/1
        [HttpGet("{id}")]
        public ActionResult<Quote> GetQuoteById(int id)
        {

            var quote = quotes.Find(q => q.Id == id);//lamda
            if (quote == null)
            {
                return NotFound();
            }
            return quote;
        }

        //For post new quote
        [HttpPost]
        public ActionResult<Quote> AddQuote(Quote newQuote)
        {
            newQuote.Id = quotes.Count + 1;
            quotes.Add(newQuote);

            //When it is success return 201
            return CreatedAtAction(nameof(GetQuoteById), new { id = newQuote.Id }, newQuote);
        }

        //For update quote
        [HttpPut("{id}")]
        public IActionResult UpdateQuote(int id, Quote updatedQuote)
        {
            var index = quotes.FindIndex(q => q.Id == id);
            if (index == -1)
            {
                return NotFound();//for 404
            }

            updatedQuote.Id = id;
            quotes[index] = updatedQuote;

            return NoContent();
        }

        //For update partially content in quote
        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdateQuote(int id, Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<Quote> patchDocument)
        {
            var quote = quotes.Find(q => q.Id == id);
            if (quote == null)
            {
                return NotFound();
            }

            patchDocument.ApplyTo(quote, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return NoContent();
        }

        //For delete quote
        [HttpDelete("{id}")]
        public IActionResult DeleteQuote(int id)
        {
            var quote = quotes.Find(q => q.Id == id);
            if (quote == null)
            {
                return NotFound();
            }

            quotes.Remove(quote);

            // Update the IDs of quotes
            for (int i = id - 1; i < quotes.Count; i++)
            {
                quotes[i].Id = i + 1;
            }

            return NoContent();
        }

        //To do List

        // Get a random quote

        // Get quotes by author
    }
}
