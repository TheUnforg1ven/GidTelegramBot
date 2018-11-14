using System.Collections.Generic;

namespace GidTelegramBot.Models
{
	public interface IQuoteRepository
	{
		IEnumerable<Quote> Quotes { get; }
	}
}
