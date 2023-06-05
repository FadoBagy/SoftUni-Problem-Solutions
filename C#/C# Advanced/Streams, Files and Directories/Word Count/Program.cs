namespace TestingConsoleApp
{
    using System;
    using System.Text.RegularExpressions;

    internal class Program
    {
        static void Main()
        {
            var words = File.ReadAllLines("words.txt");

            var textOneLine = File.ReadAllText("text.txt").Replace("\r\n", " ");
            var wordsFromText = Regex.Replace(textOneLine, "\\p{P}", "").Split(" ");
            var wordsCount = new Dictionary<string, int>();

            foreach (var word in words)
            {
                var count = wordsFromText.Count(w => w.ToLower() == word.ToLower());
                wordsCount[word] = count;
            }

            using (var sw = new StreamWriter("actualResult.txt"))
            {
                var sortedWords = wordsCount.Keys.OrderByDescending(key => wordsCount[key]).ToList();
                for (int i = 0; i < sortedWords.Count; i++)
                {
                    var word = sortedWords[i];
                    sw.Write($"{word} - {wordsCount[word]}");

                    if (i != sortedWords.Count - 1)
                    {
                        sw.WriteLine();
                    }
                }
            }

            var expectedResult = File.ReadAllText("expectedResult.txt");
            var actualResult = File.ReadAllText("actualResult.txt");
            if (expectedResult.Equals(actualResult, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Correct");
            }
            else
            {
                Console.WriteLine("Wrong");
            }
        }
    }
}