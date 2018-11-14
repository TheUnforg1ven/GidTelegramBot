using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace GidTelegramBot.Models.Commands
{
	public interface ICommand
	{
		string Name { get; }

		Task ExecuteAsync(Message message, TelegramBotClient botClient, Update update);

		bool Contains(Message message);
	}
}
