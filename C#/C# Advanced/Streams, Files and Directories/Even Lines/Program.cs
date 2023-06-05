namespace TestingConsoleApp
{
    using System;
    using System.Text.RegularExpressions;

    internal class Program
    {
        static void Main()
        {
            using var sr = new StreamReader("text.txt");
            char[] symbolsToReplace = { '-', ',', '.', '!', '?' };
            int lineCount = 0;
            string line = "";

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                if (lineCount % 2 == 0)
                {
                    string pattern = "[" + Regex.Escape(new string(symbolsToReplace)) + "]";
                    string replaced = Regex.Replace(line, pattern, "@");
                    var reversedLine = replaced.Split(" ").Reverse();
                    Console.WriteLine(string.Join(" ", reversedLine));
                }
                lineCount++;
            }
        }
    }
}