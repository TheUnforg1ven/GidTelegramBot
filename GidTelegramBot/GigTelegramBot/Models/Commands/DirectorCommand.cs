using GidTelegramBot.Services;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace GidTelegramBot.Models.Commands
{
	public class DirectorCommand : ICommand
	{
		private readonly IParserService _parserService = new ParserService();

		public string Name => "/director";

		public bool Contains(Message message) => message.Text.Contains(Name);

		public async Task ExecuteAsync(Message message, TelegramBotClient botClient, Update update)
		{
			var chatId = message.Chat.Id;
			var messageId = message.MessageId;

			var usefulMessage = Transliteration.Front(message.Text.Remove(0, message.Text.IndexOf(' ') + 1)).ToLower();

			await botClient.SendTextMessageAsync(chatId, _parserService.GetDirectorInfo(usefulMessage), replyToMessageId: messageId);
		}
	}
}
