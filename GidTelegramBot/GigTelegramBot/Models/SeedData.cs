using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace GidTelegramBot.Models
{
	public static class SeedData
	{
		public static void EnsurePopulated(IApplicationBuilder app)
		{
			using (var serviceScope = app.ApplicationServices.CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

				if (!context.Quotes.Any())
				{
					context.Quotes.AddRange(
							new Quote { QuoteText = "Честно говоря, моя дорогая, мне наплевать", QuoteInfo = "Унесённые ветром (1939)" },
							new Quote { QuoteText = "Я собираюсь сделать ему предложение, от которого он не сможет отказаться", QuoteInfo = "Крёстный отец (1972)" },
							new Quote { QuoteText = "Вы не понимаете! Я мог бы иметь класс. Я мог бы быть «претендующим». Я мог бы быть кем угодно вместо ничтожества, которым я являюсь", QuoteInfo = "В порту (1954)" },
							new Quote { QuoteText = "Тото, у меня такое ощущение, что мы больше не в Канзасе", QuoteInfo = "Волшебник страны Оз (1939)" },
							new Quote { QuoteText = "Глядя на тебя, крошка", QuoteInfo = "Касабланка (1942)" },
							new Quote { QuoteText = "Валяй, порадуй меня!", QuoteInfo = "Внезапный удар (1983)" },
							new Quote { QuoteText = "Хорошо, г-н Демилль, я готова для крупного плана", QuoteInfo = "Бульвар Сансет (1950)" },
							new Quote { QuoteText = "Да пребудет с тобой Сила!", QuoteInfo = "Звёздные войны. Эпизод IV: Новая надежда (1977)" },
							new Quote { QuoteText = "Пристегните ремни. Будет жёсткая ночка", QuoteInfo = "Всё о Еве (1950)" },
							new Quote { QuoteText = "Это ты мне сказал?", QuoteInfo = "Таксист (1976)"
						});
					context.SaveChanges();
				}
			}
		}
	}
}
