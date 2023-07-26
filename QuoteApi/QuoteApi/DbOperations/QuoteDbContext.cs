using Microsoft.EntityFrameworkCore;
using QuoteApi.Entities;

namespace QuoteApi.DbOperations
{
    public class QuoteDbContext : DbContext
    {
        public QuoteDbContext(DbContextOptions<QuoteDbContext> options) : base(options) { } 
        
        public DbSet<Quote> Quotes { get; set; }
    }
}
