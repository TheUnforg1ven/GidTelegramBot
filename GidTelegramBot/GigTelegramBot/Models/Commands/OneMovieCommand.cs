using GidTelegramBot.Services;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace GidTelegramBot.Models.Commands
{
	public class OneMovieCommand : ICommand
	{
		private readonly IParserService _parserService = new ParserService();

		public string Name => "/movie";

		public bool Contains(Message message) => message.Text.Contains(Name);

		public async Task ExecuteAsync(Message message, TelegramBotClient botClient, Update update)
		{
			var chatId = message.Chat.Id;
			var messageId = message.MessageId;

			var usefulMessage = Transliteration.Front(message.Text.Remove(0, message.Text.IndexOf(' ') + 1)).ToLower();
			var buttonMessage = message.Text.Remove(0, message.Text.IndexOf(' ') + 1);
			var resultMessage = _parserService.GetOneMovieInfo(usefulMessage);

			if (resultMessage == "Вы ввели неверное название фильма!")
			{
				await botClient.SendTextMessageAsync(chatId, resultMessage, replyToMessageId: messageId);
				return;
			}

			await botClient.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

			ReplyKeyboardMarkup ReplyKeyboard = new[]
					{
						new[] { $"Подробнее о фильме {buttonMessage}"},
						new[] { "К началу"},
					};

			await botClient.SendTextMessageAsync(chatId, _parserService.GetOneMovieInfo(usefulMessage), replyToMessageId: messageId, replyMarkup: ReplyKeyboard);
		}
	}
}
