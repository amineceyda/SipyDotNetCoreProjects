using Microsoft.EntityFrameworkCore;
using QuoteApi.Entities;

namespace QuoteApi.DbOperations
{
    public class DataGenerators
    {
        public static void initialize(IServiceProvider serviceProvider)
        {

            using (var context = new QuoteDbContext(serviceProvider.GetRequiredService<DbContextOptions<QuoteDbContext>>()))
            {
                if (context.Quotes.Any())
                {
                    return;
                }
                context.Quotes.AddRange(

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
                    );

                context.SaveChanges();


            }


        }

    }

}
    

