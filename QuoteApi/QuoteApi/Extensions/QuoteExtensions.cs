using Microsoft.EntityFrameworkCore;
using QuoteApi.Controllers;
using QuoteApi.Entities;

namespace QuoteApi.Extensions
{
    public static class QuoteExtensions
    {
        //method for find total quote count in databese
        public static int GetTotalQuoteCount(this QuoteController quoteController)
        {
            return quoteController._context.Quotes.Count();

        }

        //method for find a quote by its text
        public static Quote GetQuoteByText(this QuoteController quoteController, string text)
        {
            var quote = quoteController._context.Quotes.FirstOrDefault(x => x.Text == text);
            return quote;
        }

        //method for find quotes by partial text
        public static List<Quote> GetQuotesByPartialText(this QuoteController quoteController, string partialText)
        {
            var quotes = quoteController._context.Quotes.Where(x => x.Text.Contains(partialText)).ToList();
            return quotes;
        }
    }
}


/*
 With Extensions I can add new methods to this class that are related to the QuoteController or the Quote entity.
*/
