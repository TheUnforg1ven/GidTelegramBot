using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace GidTelegramBot.Models.Commands
{
	public class AboutCommand : ICommand
	{
		public string Name => "Про бота";

		public bool Contains(Message message) => message.Text.Contains(Name);

		public async Task ExecuteAsync(Message message, TelegramBotClient botClient, Update update)
		{
			var chatId = message.Chat.Id;
			var messageId = message.MessageId;

			await botClient.SendTextMessageAsync(chatId, InfoAboutBot(), replyToMessageId: messageId);
		}

		private string InfoAboutBot()
		{
			var info = "Этот бот создан для удобного поиска лучших фильмов и их дальнейшего просмотра 😏\n\n" +
						"⭐ Вы можете:\n\n😋 Подобрать лучшие фильмы по жанру\n😎 Найти случайный фильм\n😊 Найти лучшие новинки\n\n" +
						"😁 Найти фильмы с нужным вам актером\n😛 Найти фильмы с нужным вам режиссером\n😙 Найти фильмы с нужным вам фильмом\n" +
						"😉 Найти фильмы за нужный вам год\n\n" +
						"📗 Вы можете найти больше информации командой /help\n\n" +
						"\nВсем удачи и приятного использования бота ✋";

			return info;
		}
	}
}
