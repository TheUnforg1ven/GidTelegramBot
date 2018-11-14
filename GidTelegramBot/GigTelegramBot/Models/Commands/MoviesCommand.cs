using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace GidTelegramBot.Models.Commands
{
	public class MoviesCommand : ICommand
	{
		public string Name => "Фильмы";

		public bool Contains(Message message) => message.Text.Contains(Name);

		public async Task ExecuteAsync(Message message, TelegramBotClient botClient, Update update)
		{
			var chatId = message.Chat.Id;
			var messageId = message.MessageId;

			ReplyKeyboardMarkup ReplyKeyboard = new[]
					{
						new[] { "Семейный", "История", "Вестерн"},
						new[] { "Сериалы", "Комедия", "Биография"},
						new[] { "Спорт", "Криминал", "Боевик"},
						new[] { "Триллер", "Мелодрама", "Военный"},
						new[] { "Ужасы", "Музыка", "Детектив"},
						new[] { "Фэнтези", "Мультфильм", "Драма"},
						new[] { "Фантастика", "Приключения", "Документальный" },
						new[] { "К началу" }
					};

			await botClient.SendTextMessageAsync(message.Chat.Id, "Выбери нужный тебе жанр 👇", replyMarkup: ReplyKeyboard);
		}
	}
}

