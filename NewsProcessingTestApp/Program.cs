using NewsAPI.Constants;
using NewsAPI.Models;
using NewsProcessingTestApp.Helpers;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            while (true)
            {
                var word = GetKeyWord();
                var articles = NewsHelper.GetArticles(word, Languages.RU, Languages.EN);

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
        string word = string.Empty;

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
            PrintTextWithMaxVowelsWord(article.Author, article.Title, article.Description, article.Content);
            Console.WriteLine("\n==========\n");
        }
    }

    /// <summary>
    /// Вывод текстов с информацией о слове с максимальным числом гласных в них
    /// </summary>
    private static void PrintTextWithMaxVowelsWord(params string[] texts)
    {
        foreach (var text in texts)
            PrintTextWithMaxVowelsWord(text);
    }

    /// <summary>
    /// Вывод текста с информацией о слове с максимальным числом гласных в нем
    /// </summary>
    private static void PrintTextWithMaxVowelsWord(string text)
    {
        Console.WriteLine(text + "\n");

        var maxVowelsWord = TextHelper.GetWordWithMaximumVowels(text);

        if (string.IsNullOrWhiteSpace(maxVowelsWord.Value))
            return;

        Console.WriteLine($"Слово с максимальным количеством гласных: {maxVowelsWord.Value}");
        Console.WriteLine($"Количество гласных: {maxVowelsWord.VowelsCount}\n");
    }
}