using System.Threading.Tasks;

namespace GidTelegramBot.Services
{
	public interface IParserService
	{
		string RandomInfo { get; set; }

		string GetMoreMovieInfo(string choise);

		string GetOneMovieInfo(string choise);

		string GetYearMovieInfo(string choise);

		string GetDirectorInfo(string choise);

		string GetActorInfo(string choise);

		string GetMovieInfo(string choise);

		string GetNewMoviesInfo();

		string GetRandomMovie();

		string GetSoonMoviesInfo();
	}
}
