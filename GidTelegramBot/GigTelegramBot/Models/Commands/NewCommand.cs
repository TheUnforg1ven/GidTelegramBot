using GidTelegramBot.Services;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace GidTelegramBot.Models.Commands
{
	public class NewCommand : ICommand
	{
		private readonly IParserService _parserService = new ParserService();

		public string Name => "Новинки";

		public bool Contains(Message message) => message.Text.Contains(Name);

		public async Task ExecuteAsync(Message message, TelegramBotClient botClient, Update update)
		{
			await botClient.SendTextMessageAsync(message.Chat.Id, _parserService.GetNewMoviesInfo(), replyToMessageId: message.MessageId);
		}
	}
}
