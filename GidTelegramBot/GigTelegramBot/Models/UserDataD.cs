using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace GidTelegramBot.Models
{
	public static class UserDataD
	{
		public static void EnsurePopulated(IApplicationBuilder app)
		{
			using (var serviceScope = app.ApplicationServices.CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
				//context.Database.Migrate();

				if (!context.Quotes.Any())
				{
					context.UserDatas
						.AddRange(
							new UserData {  FirstName = "David", LastName = "Fincher", FirstUseTime = DateTime.Now, UserName = "@fincher"},
							new UserData { FirstName = "Stiven", LastName = "King", FirstUseTime = DateTime.Now, UserName = "@kinger" },
							new UserData { FirstName = "Kevin", LastName = "Danker", FirstUseTime = DateTime.Now, UserName = "@checktheway" }
								);

					context.SaveChanges();
				}
			}
		}
	}
}
