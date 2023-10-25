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
        public static async Task<List<Article>> GetArticlesAsync(string query, params Languages[] languages)
        {
            var tasks = new List<Task<List<Article>>>();

            foreach (var language in languages)
                tasks.Add(GetArticlesAsync(query, language));

            return (await Task.WhenAll(tasks)).SelectMany(x => x).ToList();
        }

        /// <summary>
        /// Получить список новостных статей
        /// </summary>
        /// <param name="query">Ключевое слово по которому искать новости</param>
        /// <param name="language">Язык новостей</param>
        public static async Task<List<Article>> GetArticlesAsync(string query, Languages language)
        {
            var articlesResponse = await _newsApiClient.GetEverythingAsync(new EverythingRequest
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
