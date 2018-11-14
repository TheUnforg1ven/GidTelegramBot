using GidTelegramBot.Services;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace GidTelegramBot.Models.Commands
{
	public class FindMoviesCommand : ICommand
	{
		private readonly IParserService _parserService = new ParserService();

		public string Name => " ";

		public bool Contains(Message message) => message.Text.Contains("/") ? false : true;

		public async Task ExecuteAsync(Message message, TelegramBotClient botClient, Update update)
		{
			switch (message.Text)
			{
				case "Семейный":
					await botClient.SendTextMessageAsync(message.Chat.Id, _parserService.GetMovieInfo("semejnyj"), replyToMessageId: message.MessageId);
					break;
				case "История":
					await botClient.SendTextMessageAsync(message.Chat.Id, _parserService.GetMovieInfo("istoriya"), replyToMessageId: message.MessageId);
					break;
				case "Вестерн":
					await botClient.SendTextMessageAsync(message.Chat.Id, _parserService.GetMovieInfo("vestern"), replyToMessageId: message.MessageId);
					break;
				case "Сериалы":
					await botClient.SendTextMessageAsync(message.Chat.Id, _parserService.GetMovieInfo("serial"), replyToMessageId: message.MessageId);
					break;
				case "Комедия":
					await botClient.SendTextMessageAsync(message.Chat.Id, _parserService.GetMovieInfo("komediya"), replyToMessageId: message.MessageId);
					break;
				case "Биография":
					await botClient.SendTextMessageAsync(message.Chat.Id, _parserService.GetMovieInfo("biografiya"), replyToMessageId: message.MessageId);
					break;
				case "Спорт":
					await botClient.SendTextMessageAsync(message.Chat.Id, _parserService.GetMovieInfo("sport"), replyToMessageId: message.MessageId);
					break;
				case "Криминал":
					await botClient.SendTextMessageAsync(message.Chat.Id, _parserService.GetMovieInfo("kriminal"), replyToMessageId: message.MessageId);
					break;
				case "Боевик":
					await botClient.SendTextMessageAsync(message.Chat.Id, _parserService.GetMovieInfo("boevik"), replyToMessageId: message.MessageId);
					break;
				case "Триллер":
					await botClient.SendTextMessageAsync(message.Chat.Id, _parserService.GetMovieInfo("triller"), replyToMessageId: message.MessageId);
					break;
				case "Мелодрама":
					await botClient.SendTextMessageAsync(message.Chat.Id, _parserService.GetMovieInfo("melodrama"), replyToMessageId: message.MessageId);
					break;
				case "Военный":
					await botClient.SendTextMessageAsync(message.Chat.Id, _parserService.GetMovieInfo("voennyj"), replyToMessageId: message.MessageId);
					break;
				case "Ужасы":
					await botClient.SendTextMessageAsync(message.Chat.Id, _parserService.GetMovieInfo("uzhasy"), replyToMessageId: message.MessageId);
					break;
				case "Музыка":
					await botClient.SendTextMessageAsync(message.Chat.Id, _parserService.GetMovieInfo("muzyka"), replyToMessageId: message.MessageId);
					break;
				case "Детектив":
					await botClient.SendTextMessageAsync(message.Chat.Id, _parserService.GetMovieInfo("detektiv"), replyToMessageId: message.MessageId);
					break;
				case "Фэнтези":
					await botClient.SendTextMessageAsync(message.Chat.Id, _parserService.GetMovieInfo("fentezi"), replyToMessageId: message.MessageId);
					break;
				case "Мультфильм":
					await botClient.SendTextMessageAsync(message.Chat.Id, _parserService.GetMovieInfo("multfilm"), replyToMessageId: message.MessageId);
					break;
				case "Драма":
					await botClient.SendTextMessageAsync(message.Chat.Id, _parserService.GetMovieInfo("drama"), replyToMessageId: message.MessageId);
					break;
				case "Фантастика":
					await botClient.SendTextMessageAsync(message.Chat.Id, _parserService.GetMovieInfo("fantastika"), replyToMessageId: message.MessageId);
					break;
				case "Приключения":
					await botClient.SendTextMessageAsync(message.Chat.Id, _parserService.GetMovieInfo("priklyucheniya"), replyToMessageId: message.MessageId);
					break;
				case "Документальный":
					await botClient.SendTextMessageAsync(message.Chat.Id, _parserService.GetMovieInfo("dokumentalnyj"), replyToMessageId: message.MessageId);
					break;
				default:
					await botClient.SendTextMessageAsync(message.Chat.Id, "Я не понимаю такой команды :С", replyToMessageId: message.MessageId);
					break;
			}	
		}
	}
}
