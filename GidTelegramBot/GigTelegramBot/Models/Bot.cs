using GidTelegramBot.Models.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;

namespace GidTelegramBot.Models
{
	public static class Bot
	{
		private static TelegramBotClient botClient;
		private static List<ICommand> commandsList;

		public static IReadOnlyList<ICommand> Commands => commandsList.AsReadOnly();

		public static async Task<TelegramBotClient> GetBotClientAsync()
		{
			if (botClient != null)
			{
				return botClient;
			}

			commandsList = new List<ICommand>
			{
				new StartCommand(),
				new RefreshCommand(),
				new ActorCommand(), // test actor command with state
				new DirectorCommand(),
				new YearMovieCommand(),
				new OneMovieCommand(), // test and complete single movie command
				new HelpCommand(),
				new MoviesCommand(),
				new QuoteCommand(),
				new OriginCommand(),
				new RandomCommand(),
				new SoonCommand(),
				new NewCommand(),
				new AboutCommand(),
				new MoreMovieCommand(),
				new FindMoviesCommand()					
			};

			botClient = new TelegramBotClient(AppSettings.Key);
			var hook = String.Format(AppSettings.Url, "api/message/update");
			await botClient.SetWebhookAsync(hook);
			return botClient;
		}
	}
}
