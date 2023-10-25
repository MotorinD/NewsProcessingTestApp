using NewsAPI.Constants;
using NewsAPI.Models;
using NewsProcessingTestApp.Helpers;
using NewsProcessingTestApp.Logic.ShowData;
using NewsProcessingTestApp.Logic.ShowData.ShowDataBehaviour;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            while (true)
            {
                var word = GetKeyWord();
                var articles = NewsHelper.GetArticlesAsync(word, Languages.RU, Languages.EN).Result;

                PrintArticles(articles);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadLine();
        }
    }

    /// <summary>
    /// Получить от пользователя слово для поиска новостных статей
    /// </summary>
    private static string GetKeyWord()
    {
        string? word = string.Empty;
        do
        {
            Console.WriteLine("Введите слово для поиска новостных статей");
            word = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(word));

        return word;
    }

    /// <summary>
    /// Вывод новостных статей
    /// </summary>
    private static void PrintArticles(List<Article> articles)
    {
        if (articles.Count == 0)
        {
            Console.WriteLine("Не найдено новостных статей");
            return;
        }
        
        foreach (var article in articles)
        {
            Console.WriteLine("\n=====================================================================\n");
            PrintTextWithMaxVowelsWord(article.Author, article.Title, article.Description, article.Content);
        }
    }

    /// <summary>
    /// Вывод текстов с информацией о слове с максимальным числом гласных в них
    /// </summary>
    private static void PrintTextWithMaxVowelsWord(params string[] texts)
    {
        foreach (var text in texts)
            new ShowDataConsole(text, new ShowDataBehaviourConsole()).ShowData();
    }
}