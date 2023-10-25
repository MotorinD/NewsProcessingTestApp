using NewsProcessingTestApp.Helpers;
using NewsProcessingTestApp.Interfaces.ShowData;

namespace NewsProcessingTestApp.Logic.ShowData.ShowDataBehaviour
{
    public class ShowDataBehaviourConsole : IShowDataBehaviour
    {
        public void Execute(string text)
        {
            Console.WriteLine(text + "\n");

            var maxVowelsWord = TextHelper.GetWordWithMaximumVowels(text);

            if (string.IsNullOrWhiteSpace(maxVowelsWord.Value))
                return;

            Console.WriteLine($"Слово с максимальным количеством гласных: {maxVowelsWord.Value}");
            Console.WriteLine($"Количество гласных: {maxVowelsWord.VowelsCount}\n");
        }
    }
}
