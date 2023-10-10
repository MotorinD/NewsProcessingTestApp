using NewsAPI.Constants;
using NewsAPI.Models;
using NewsAPI;

namespace NewsProcessingTestApp.Helpers
{
    public static class NewsHelper
    {
        private static readonly NewsApiClient _newsApiClient;

        static NewsHelper()
        {
            var apiKey = ConfigurationHelper.APIKey;
            _newsApiClient = new NewsApiClient(apiKey);
        }

        /// <summary>
        /// Получить список новостных статей
        /// </summary>
        /// <param name="query">Ключевое слово по которому искать новости</param>
        /// <param name="language">Язык новостей</param>
        public static List<Article> GetArticles(string query, params Languages[] languages)
        {
            var articles = new List<Article>();

            foreach(var language in languages)
                articles.AddRange(GetArticles(query, language));

            return articles;
        }

        /// <summary>
        /// Получить список новостных статей
        /// </summary>
        /// <param name="query">Ключевое слово по которому искать новости</param>
        /// <param name="language">Язык новостей</param>
        public static List<Article> GetArticles(string query, Languages language)
        {
            var articlesResponse = _newsApiClient.GetEverything(new EverythingRequest
            {
                Q = query,
                SortBy = SortBys.Popularity,
                Language = language
            });

            if (articlesResponse.Status == Statuses.Ok)
                return articlesResponse.Articles;
            else
                throw new Exception(articlesResponse.Error.Message);
        }
    }
}
