using System;
using System.ComponentModel.DataAnnotations;

namespace GidTelegramBot.Models
{
	public class UserData
	{
		[Key]
		public int UserID { get; set; }

		public int TelegramUserID { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string UserName { get; set; }

		public DateTime? FirstUseTime { get; set; }
	}
}
