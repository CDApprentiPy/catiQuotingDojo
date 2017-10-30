using Microsoft.EntityFrameworkCore;

namespace quotingDojo.Models
{
    public class QuotesContext : DbContext
    {
        public QuotesContext(DbContextOptions<QuotesContext> options) : base(options) {}
        public DbSet<Quote> Quotes { get; set; }
    }

}