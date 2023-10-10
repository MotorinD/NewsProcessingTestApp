using NewsProcessingTestApp.Models;

namespace NewsProcessingTestApp.Helpers
{
    public static class TextHelper
    {
        //гласные
        private static readonly HashSet<char> _vowelsHashSet = new HashSet<char>() 
        {
                'а','у','о','ы','э','я','ю','ё','и','е',
                'А', 'У', 'О', 'Ы', 'Э', 'Я', 'Ю', 'Ё', 'И', 'Е',
                'a', 'e', 'i', 'o', 'u', 'y',
                'A', 'E', 'I', 'O', 'U', 'Y'
        };

        //разделители
        private static readonly char[] separatorsArray = new char[] { ' ', ',', '.', ':' };

        /// <summary>
        /// Получить слово с максимальным количеством гласных из текста
        /// </summary>
        public static WordModel GetWordWithMaximumVowels(string text)
        {
            var maxVowelsWord = new WordModel();

            if (string.IsNullOrWhiteSpace(text))
                return maxVowelsWord;

            var words = text.Split(separatorsArray,StringSplitOptions.RemoveEmptyEntries);
            var vowelsCount = 0;

            foreach (var word in words)
            {
                foreach (var letter in word)
                {
                    if (_vowelsHashSet.Contains(letter))
                        vowelsCount++;
                }

                if(vowelsCount > maxVowelsWord.VowelsCount)
                {
                    maxVowelsWord.Value = word;
                    maxVowelsWord.VowelsCount = vowelsCount;
                }

                vowelsCount = 0;
            }

            return maxVowelsWord;
        }
    }
}
