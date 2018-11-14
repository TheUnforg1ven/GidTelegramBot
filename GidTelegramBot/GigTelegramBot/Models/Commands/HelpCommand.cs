using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace GidTelegramBot.Models.Commands
{
	public class HelpCommand : ICommand
	{
		public string Name => "/help";

		public bool Contains(Message message) => message.Text.Contains(Name);

		public async Task ExecuteAsync(Message message, TelegramBotClient botClient, Update update)
		{
			var chatId = message.Chat.Id;
			var messageId = message.MessageId;

			var helpMessage = "Используя данного бота вы можете: \n\n" +
							"1) Выбрать нужное вам действие используя кнопки\n" +
							"2) Использовать команды:\n\n" +
							 "Вы можете найти фильмы актера введя команду:\n /actor Имя актера\n" +
							 "Пример:  /actor Антонио Бандерас\n" +
							 "Вы можете найти фильмы режиссера введя команду:\n /director Имя режиссера\n" +
							 "Пример:  /director Стивен Спилберг\n" +
							 "Вы можете найти фильмы по году выхода введя команду:\n /year Год\n" +
							 "Пример:  /year 1984\n" +
							 "Вы можете найти фильм введя команду:\n /movie Название\n" +
							 "Пример:  /movie Бегущий по лезвию\n\n" +
							 "Так же можете ввести команду /refresh -  для обновления клавиатуры и " +
							 "/help - для просмотра данной информации";

			await botClient.SendTextMessageAsync(chatId, helpMessage, replyToMessageId: messageId);
		}
	}
}
