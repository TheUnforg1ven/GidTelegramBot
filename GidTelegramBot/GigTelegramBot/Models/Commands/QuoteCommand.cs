using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace GidTelegramBot.Models.Commands
{
	public class QuoteCommand : ICommand
	{
		public string Name => "Цитаты";

		public bool Contains(Message message) => message.Text.Contains(Name);

		public async Task ExecuteAsync(Message message, TelegramBotClient botClient, Update update)
		{
			var chatId = message.Chat.Id;
			var messageId = message.MessageId;

			var quote = GetQuote();

			await botClient.SendTextMessageAsync(chatId, $"{quote.QuoteText} \n\n📗{quote.QuoteInfo}", replyToMessageId: messageId);
		}

		private Quote GetQuote()
		{
			var random = new Random();

			var quotes = new List<Quote>
			{
				new Quote { QuoteText = "Честно говоря, моя дорогая, мне наплевать", QuoteInfo = "Унесённые ветром (1939)" },
				new Quote { QuoteText = "Я собираюсь сделать ему предложение, от которого он не сможет отказаться", QuoteInfo = "Крёстный отец (1972)" },
				new Quote { QuoteText = "Вы не понимаете! Я мог бы иметь класс. Я мог бы быть «претендующим». Я мог бы быть кем угодно вместо ничтожества, которым я являюсь", QuoteInfo = "В порту (1954)" },
				new Quote { QuoteText = "Тото, у меня такое ощущение, что мы больше не в Канзасе", QuoteInfo = "Волшебник страны Оз (1939)" },
				new Quote { QuoteText = "Глядя на тебя, крошка", QuoteInfo = "Касабланка (1942)" },
				new Quote { QuoteText = "Валяй, порадуй меня!", QuoteInfo = "Внезапный удар (1983)" },
				new Quote { QuoteText = "Хорошо, г-н Демилль, я готова для крупного плана", QuoteInfo = "Бульвар Сансет (1950)" },
				new Quote { QuoteText = "Да пребудет с тобой Сила!", QuoteInfo = "Звёздные войны. Эпизод IV: Новая надежда (1977)" },
				new Quote { QuoteText = "Пристегните ремни. Будет жёсткая ночка", QuoteInfo = "Всё о Еве (1950)" },
				new Quote { QuoteText = "Это ты мне сказал?", QuoteInfo = "Таксист (1976)" }
			};

			int randomGenre = random.Next(10);

			quotes.ToArray();

			return quotes[randomGenre];
		}
	}
}
