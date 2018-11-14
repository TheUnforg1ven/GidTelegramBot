using Microsoft.EntityFrameworkCore;

namespace GidTelegramBot.Models
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
			: base(options) { }

		public DbSet<Quote> Quotes { get; set; }

		public DbSet<UserData> UserDatas { get; set; }
	}
}
