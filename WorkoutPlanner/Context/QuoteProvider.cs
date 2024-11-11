using Microsoft.EntityFrameworkCore;
using WorkoutPlanner.Model;

namespace WorkoutPlanner.Context
{
    public class QuoteProvider
    {
        private readonly DatabaseContext _context;

        public QuoteProvider(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Quote>> GetAllQuotesAsync()
        {
            return await _context.Quotes.OrderBy(quote => quote.QuoteName).ToListAsync();
        }

        public Quote? GetQuote(int id)
        {
            return _context.Quotes.Find(id);
        }

        public async Task<Quote> GetRandomQuoteAsync()
        {
            int count = await _context.Quotes.CountAsync();
            if (count == 0)
            {
                return null;
            }
            int randomIndex = new Random().Next(count);
            return await _context.Quotes.Skip(randomIndex).FirstOrDefaultAsync();
        }

    }
}
