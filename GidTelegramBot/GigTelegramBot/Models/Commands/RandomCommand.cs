using GidTelegramBot.Services;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace GidTelegramBot.Models.Commands
{
	public class RandomCommand : ICommand
	{
		private readonly IParserService _parserService = new ParserService();

		public string Name => "Рандом";

		public bool Contains(Message message) => message.Text.Contains(Name);

		public async Task ExecuteAsync(Message message, TelegramBotClient botClient, Update update)
		{
			var chatId = message.Chat.Id;
			var messageId = message.MessageId;

			//await botClient.SendTextMessageAsync(chatId, _parserService.GetRandomMovie(), replyToMessageId: messageId);

			await botClient.SendPhotoAsync(chatId, _parserService.GetRandomMovie(),  _parserService.RandomInfo, replyToMessageId: messageId);
		}
	}
}
