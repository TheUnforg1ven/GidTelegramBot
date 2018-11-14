using GidTelegramBot.Models;
using GidTelegramBot.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GidTelegramBot
{
    public class Startup
    {
		IConfigurationRoot Configuration;

		public Startup(IHostingEnvironment env)
		{
			Configuration = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json")
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
				.Build();
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
			options.UseSqlServer(Configuration["Data:BotQuotes:ConnectionString"]));
			services.AddTransient<IQuoteRepository, EFQuoteRepository>();
			services.AddTransient<IUserDataRepository, EFUserDataRepository>();

			services.AddSingleton<IParserService, ParserService>();
			services.AddMvc();
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseDeveloperExceptionPage();
			app.UseBrowserLink();
			app.UseStatusCodePages();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});

			//SeedData.EnsurePopulated(app);
			//UserDataD.EnsurePopulated(app);

			Bot.GetBotClientAsync().Wait();
		}
	}
}
