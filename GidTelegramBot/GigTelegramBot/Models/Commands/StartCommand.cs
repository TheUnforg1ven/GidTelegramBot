using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace GidTelegramBot.Models.Commands
{
	public class StartCommand : ICommand
	{
		public string Name => "/start";

		public bool Contains(Message message) => message.Text.Contains(Name);

		public async Task ExecuteAsync(Message message, TelegramBotClient botClient, Update update)
		{
			var chatId = message.Chat.Id;
			var messageId = message.MessageId;
			var userUserName = message.From.Username ?? "<NoUserName>";
			var userFirstName = message.From.FirstName ?? "<NoFirstName>";
			var userLastName = message.From.LastName ?? "<NoLastName>";

			ReplyKeyboardMarkup ReplyKeyboard = new[]
					{
						new[] { "Фильмы", "Цитаты", "Рандом"},
						new[] { "Скоро на экранах", "Новинки", "Про бота"}
					};

			await botClient.SendTextMessageAsync(chatId, $"Привет, {userFirstName}, я GidBot, помогу тебе выбрать фильм по вкусу :з", replyToMessageId: messageId);

			await botClient.SendTextMessageAsync(message.Chat.Id, "Выбери то, что тебе интересно 😜👇", replyMarkup: ReplyKeyboard);
		}
	}
}
