using GidTelegramBot.Services;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace GidTelegramBot.Models.Commands
{
	public class MoreMovieCommand : ICommand
	{
		private readonly IParserService _parserService = new ParserService();

		public string Name => "Подробнее о фильме";

		public bool Contains(Message message) => message.Text.Contains(Name);

		public async Task ExecuteAsync(Message message, TelegramBotClient botClient, Update update)
		{
			if (message.Text.Length <= 18)
				return;

			var chatId = message.Chat.Id;
			var messageId = message.MessageId;

			var changedName = Transliteration.Front(message.Text.Remove(0, 18)).ToLower();

			await botClient.SendTextMessageAsync(chatId, _parserService.GetMoreMovieInfo(changedName), replyToMessageId: messageId);

			// in the end, when all needed logic is done
			ReplyKeyboardMarkup ReplyKeyboard = new[]
					{
						new[] { "Фильмы", "Цитаты", "Рандом"},
						new[] { "Скоро на экранах", "Новинки", "Про бота"}
					};

			await botClient.SendTextMessageAsync(message.Chat.Id, "Выбери то, что тебе интересно 😜👇", replyMarkup: ReplyKeyboard);
		}
	}
}
