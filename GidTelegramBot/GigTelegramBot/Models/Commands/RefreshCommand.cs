using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace GidTelegramBot.Models.Commands
{
	public class RefreshCommand : ICommand
	{
		public string Name => "/refresh";

		public bool Contains(Message message) => message.Text.Contains(Name);

		public async Task ExecuteAsync(Message message, TelegramBotClient botClient, Update update)
		{
			var chatId = message.Chat.Id;
			var messageId = message.MessageId;

			ReplyKeyboardMarkup ReplyKeyboard = new[]
					{
						new[] { "Фильмы", "Цитаты", "Рандом"},
						new[] { "Скоро на экранах", "Новинки", "Про бота"}
					};

			await botClient.SendTextMessageAsync(message.Chat.Id, "Клавиатура перезагружена! 🍀👇", replyMarkup: ReplyKeyboard);
		}
	}
}
