using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace GidTelegramBot.Models.Commands
{
	public class OriginCommand : ICommand
	{
		public string Name => "К началу";

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

			await botClient.SendTextMessageAsync(message.Chat.Id, "Выбери то, что тебе интересно 😜👇", replyMarkup: ReplyKeyboard);
		}
	}
}
