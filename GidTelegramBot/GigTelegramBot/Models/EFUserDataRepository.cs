using System.Collections.Generic;
using System.Linq;

namespace GidTelegramBot.Models
{
	public class EFUserDataRepository : IUserDataRepository
	{
		private ApplicationDbContext context;

		public EFUserDataRepository(ApplicationDbContext ctx)
		{
			context = ctx;
		}

		public IEnumerable<UserData> UserDatas => context.UserDatas;

		public void SaveUserData(UserData user)
		{

			if (context.UserDatas.Count() == 0)
				context.UserDatas.Add(user);

			else
			{
				var dbContains = context.UserDatas.Any(u => u.TelegramUserID == user.TelegramUserID);

				if (!dbContains)
					context.UserDatas.Add(user);
			}

			context.SaveChanges();
		}
	}
}
