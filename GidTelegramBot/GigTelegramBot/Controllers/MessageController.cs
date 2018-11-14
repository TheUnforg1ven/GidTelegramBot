using GidTelegramBot.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Microsoft.Extensions.Logging;

namespace GidTelegramBot.Controllers
{
	[Route("api/message/update")]
	public class MessageController : Controller
	{
		private IUserDataRepository userData;
		private ILogger<MessageController> logger;

		public MessageController(IUserDataRepository data, ILogger<MessageController> log)
		{
			userData = data;
			logger = log;
		}

		/// <summary>
		/// Simple get method
		/// </summary>
		[HttpGet]
		public string Get()
		{
			return "Method GET as good as always";
		}

		/// <summary>
		/// Add new user into db and initialize chosen command
		/// </summary>
		/// <returns> OkResult </returns>
		[HttpPost]
		public async Task<OkResult> Post([FromBody]Update update)
		{
			if (update == null)
				return Ok();

			var commands = Bot.Commands;
			var message = update.Message;
			var botClient = await Bot.GetBotClientAsync();

			var _userTelegramID = message.From.Id;
			var _userFirstName = message.From.FirstName ?? "<NoFirstName>";
			var _userLastName = message.From.LastName ?? "<NoLastName>";
			var _userUserName = message.From.Username ?? "<NoUserName>";

			var data = new UserData
			{
				TelegramUserID = _userTelegramID,
				FirstName = _userFirstName,
				LastName = _userLastName,
				UserName = _userUserName,
				FirstUseTime = DateTime.Now
			};

			foreach (var command in commands)
			{
				if (command.Contains(message))
				{
					if (message.Text == "/start")
					{
						userData.SaveUserData(data);
						await command.ExecuteAsync(message, botClient, update);
						break;
					}

					else
					{
						await command.ExecuteAsync(message, botClient, update);
						break;
					}
				}
			}
			return Ok();
		}
	}
}
