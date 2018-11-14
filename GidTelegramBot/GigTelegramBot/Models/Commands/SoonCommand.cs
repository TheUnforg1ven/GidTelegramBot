using GidTelegramBot.Services;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace GidTelegramBot.Models.Commands
{
	public class SoonCommand : ICommand
	{
		private readonly IParserService _parserService = new ParserService();

		public string Name => "Скоро на экранах";

		public bool Contains(Message message) => message.Text.Contains(Name);

		public async Task ExecuteAsync(Message message, TelegramBotClient botClient, Update update)
		{
			await botClient.SendTextMessageAsync(message.Chat.Id, _parserService.GetSoonMoviesInfo(), replyToMessageId: message.MessageId);
		}
	}
}
