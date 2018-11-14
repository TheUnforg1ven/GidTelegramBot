using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace GidTelegramBot.Services
{
	public class ParserService : IParserService
	{
		public string RandomInfo { get; set; }

		public string GetMoreMovieInfo(string choise)
		{
			var document = ParseSettings($"film/{choise}");
			var strResult = "📌 Ваш фильм: ";

			//var menuName = document
			//				.QuerySelectorAll("h1[itemprop$='name']")
			//				.FirstOrDefault();

			//var menuCountry = document
			//					.QuerySelectorAll("a[href*='http://gidonline.in/country/']")
			//					.ToList();

			//var menuGenre = document
			//				.QuerySelectorAll("a[href*='http://gidonline.in/genre/']")
			//				.ToList();

			var menuItems = document
							.QuerySelectorAll("div")
							.Where(item => item.ClassName != null && item.ClassName.Contains("rl-2"))
							.ToArray();

			if (menuItems.Length == 0)
				return "Вы ввели неверное название фильма!";

			var menuActors = document
							.QuerySelectorAll("div")
							.Where(item => item.ClassName != null && item.ClassName.Contains("rll"))
							.FirstOrDefault();

			var menuRating= document
							.QuerySelectorAll("div")
							.Where(item => item.ClassName != null && item.ClassName.Contains("ratings-score"))
							.FirstOrDefault();

			var menuInfo = document
							.QuerySelectorAll("div")
							.Where(item => item.ClassName != null && item.ClassName.Contains("infotext"))
							.ToList();

			strResult += $"{menuItems[0].TextContent} \n";
			strResult += $"📆 Год: {menuItems[1].TextContent} \n";
			strResult += $"🏁 Страна: {menuItems[2].TextContent} \n";
			strResult += $"🍀 Жанр: {menuItems[3].TextContent} \n";
			strResult += $"⏳ Время: {menuItems[4].TextContent} \n";
			strResult += $"💿Просмотр: {menuItems[5].TextContent.Replace("\n", string.Empty).Replace(" ", string.Empty)} \n";
			strResult += $"🎬 Режиссер: {menuItems[6].TextContent} \n";
			strResult += $"✅ В главных ролях: {menuActors.TextContent} \n";
			strResult += $"📈 Рейтинг фильма: {menuRating.TextContent.Remove(0, 15)} \n\n";

			strResult += $"📕 Про фильм: \n";

			foreach (var info in menuInfo)
			{
				strResult += $"{info.TextContent} \n";
			}

			strResult = strResult.Remove(strResult.LastIndexOf('©'), 11);

			return strResult;
		}

		public string GetOneMovieInfo(string choise)
		{
			var document = ParseSettings($"film/{choise}");
			var strResult = "☕ Ваш фильм ";

			var menuPics = document
						.QuerySelectorAll("img[src$='_200x300.jpg']")
						.Select(p => p.GetAttribute("src"))
						.ToArray();

			if (menuPics.Length == 0)
				return "Вы ввели неверное название фильма!";

			strResult += $"доступен по ссылке:\n\n http://gidonline.in/film/{choise}";

			return strResult;
		}

		public string GetYearMovieInfo(string choise)
		{
			var document = ParseSettings($"year/in-{choise}/rating");
			var strResult = "🔥 Топ лучших фильмов этого года:\n\n";

			var menuItems = document
							.QuerySelectorAll("a")
							.Where(item => item.ClassName != null && item.ClassName.Contains("mainlink"))
							.Select(m => ((IHtmlAnchorElement)m).Href)
							.Take(10)
							.ToArray();

			var menuNames = document
							.All
							.Where(m => m.LocalName == "span" && m.TextContent != "|")
							.Take(10)
							.ToArray();

			if (menuNames.Length == 0 || menuItems.Length == 0)
				return "Вы ввели неверный год!";

			for (int i = 0; i < menuItems.Length; i++)
				strResult += $"{i + 1}.\t{menuNames[i].TextContent}\n{menuItems[i]}\n";

			strResult += $"\nБольше фильмов по ссылке: http://gidonline.in/year/in-{choise}/rating/";

			return strResult;
		}

		public string GetDirectorInfo(string choise)
		{
			var document = ParseSettings($"director/{choise}/rating");
			var strResult = "🔥 Топ лучших фильмов этого режиссера:\n\n";

			var menuItems = document
							.QuerySelectorAll("a")
							.Where(item => item.ClassName != null && item.ClassName.Contains("mainlink"))
							.Select(m => ((IHtmlAnchorElement)m).Href)
							.Take(10)
							.ToArray();

			var menuNames = document
							.All
							.Where(m => m.LocalName == "span" && m.TextContent != "|")
							.Take(10)
							.ToArray();

			if (menuNames.Length == 0 || menuItems.Length == 0)
				return "Вы ввели неверное имя режиссера!";

			for (int i = 0; i < menuItems.Length; i++)
				strResult += $"{i + 1}.\t{menuNames[i].TextContent}\n{menuItems[i]}\n";

			strResult += $"\nБольше фильмов по ссылке: http://gidonline.in/director/{choise}/rating/";

			return strResult;
		}

		public string GetActorInfo(string choise)
		{
			var document = ParseSettings($"actors/{choise}/rating");
			var strResult = "🔥 Топ лучших фильмов этого актера:\n\n";

			var menuItems = document
							.QuerySelectorAll("a")
							.Where(item => item.ClassName != null && item.ClassName.Contains("mainlink"))
							.Select(m => ((IHtmlAnchorElement)m).Href)
							.Take(10)
							.ToArray();

			var menuNames = document
							.All
							.Where(m => m.LocalName == "span" && m.TextContent != "|")
							.Take(10)
							.ToArray();

			if (menuNames.Length == 0 || menuItems.Length == 0)
				return "Вы ввели неверное имя актера!";

			for (int i = 0; i < menuItems.Length; i++)
				strResult += $"{i + 1}.\t{menuNames[i].TextContent}\n{menuItems[i]}\n";

			strResult += $"\nБольше фильмов по ссылке: http://gidonline.in/actors/{choise}/rating/";

			return strResult;
		}

		public string GetMovieInfo(string choise)
		{
			var document = ParseSettings($"genre/{choise}/rating");
			var strResult = "🔥 Топ-10 лучших фильмов в этом жанре:\n\n";

			var menuItems = document
							.QuerySelectorAll("a")
							.Where(item => item.ClassName != null && item.ClassName.Contains("mainlink"))
							.Select(m => ((IHtmlAnchorElement)m).Href)
							.Take(10)
							.ToArray();

			var menuNames = document
							.All
							.Where(m => m.LocalName == "span" && m.TextContent != "|")
							.Take(10)
							.ToArray();

			for (int i = 0; i < 10; i++)
			{
				strResult += $"{i+1}.\t{menuNames[i].TextContent}\n{menuItems[i]}\n";
			}

			strResult += $"\nБольше фильмов по ссылке: http://gidonline.in/genre/{choise}/rating/";

			return strResult;
		}

		public string GetRandomMovie()
		{
			var genres = new [] { "semejnyj", "istoriya", "vestern", "serial", "komediya", "biografiya", "sport",
								"kriminal", "boevik", "triller", "melodrama", "voennyj", "uzhasy", "muzyka",
								"detektiv", "fentezi", "multfilm", "drama", "fantastika", "priklyucheniya", "dokumentalnyj" };

			var rnd = new Random();
			int randomGenre = rnd.Next(21);

			var document = ParseSettings($"genre/{genres[randomGenre]}");

			var strResult = "☕ Случайный фильм для вас:\n\n";

			var menuItems = document
							.QuerySelectorAll("a")
							.Where(item => item.ClassName != null && item.ClassName.Contains("mainlink"))
							.Select(m => ((IHtmlAnchorElement)m).Href)
							.ToArray();

			var menuNames = document
							.All
							.Where(m => m.LocalName == "span" && m.TextContent != "|")
							.ToArray();

			var menuPics = document
							.QuerySelectorAll("img[src$='_200x300.jpg']")
							.Select(p => p.GetAttribute("src"))
							.ToArray();

			int randomFilm = rnd.Next(12);

			strResult += $"✅ {menuNames[randomFilm].TextContent}\n{menuItems[randomFilm]}\n";

			RandomInfo = strResult;

			var randomPicture = $"http://gidonline.in{menuPics[randomFilm]}";

			return randomPicture;
		}

		public string GetNewMoviesInfo()
		{
			var document = ParseSettings("premiers");
			var strResult = "🔥 Топ-10 лучших новых фильмов:\n\n";

			var menuItems = document
							.QuerySelectorAll("a")
							.Where(item => item.ClassName != null && item.ClassName.Contains("mainlink"))
							.Select(m => ((IHtmlAnchorElement)m).Href)
							.Take(10)
							.ToArray();

			var menuNames = document
							.All
							.Where(m => m.LocalName == "span" && m.TextContent != "|")
							.Take(10)
							.ToArray();

			for (int i = 0; i < 10; i++)
			{
				strResult += $"{i + 1}.\t{menuNames[i].TextContent}\n{menuItems[i]}\n";
			}

			strResult += $"\nБольше фильмов по ссылке: http://gidonline.in/premiers/";

			return strResult;
		}

		public string GetSoonMoviesInfo()
		{
			var document = ParseSettings("new");
			var strResult = "🔥 Топ-10 фильмов, которые скоро выйдут:\n\n";

			var menuItems = document
							.QuerySelectorAll("a")
							.Where(item => item.ClassName != null && item.ClassName.Contains("mainlink"))
							.Select(m => ((IHtmlAnchorElement)m).Href)
							.Take(10)
							.ToArray();

			var menuNames = document
							.All
							.Where(m => m.LocalName == "span" && m.TextContent != "|")
							.Take(10)
							.ToArray();

			for (int i = 0; i < 10; i++)
			{
				strResult += $"{i + 1}.\t{menuNames[i].TextContent}\n{menuItems[i]}\n";
			}

			strResult += $"\nБольше фильмов по ссылке: http://gidonline.in/new/";

			return strResult;
		}

		private IHtmlDocument ParseSettings(string genre)
		{
			var _client = new HttpClient();
			var _domParser = new HtmlParser();

			var response = _client.GetAsync($"http://gidonline.in/{genre}/").Result;
			string sourse = null;

			if (response != null && response.StatusCode == HttpStatusCode.OK)
				sourse = response.Content.ReadAsStringAsync().Result;

			var document = _domParser.Parse(sourse);

			return document;
		}
	}
}
