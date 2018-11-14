using System.Collections.Generic;

namespace GidTelegramBot.Models
{
	public interface IUserDataRepository
	{
		IEnumerable<UserData> UserDatas { get; }

		void SaveUserData(UserData user);
	}
}
