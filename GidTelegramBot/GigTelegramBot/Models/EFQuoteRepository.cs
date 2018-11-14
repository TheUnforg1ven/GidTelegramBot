using System.Collections.Generic;

namespace GidTelegramBot.Models
{
	public class EFQuoteRepository : IQuoteRepository
	{
		private ApplicationDbContext _context;

		public EFQuoteRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<Quote> Quotes => _context.Quotes;
	}
}
