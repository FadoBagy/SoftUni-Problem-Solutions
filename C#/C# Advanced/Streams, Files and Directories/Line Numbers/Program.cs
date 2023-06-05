namespace TestingConsoleApp
{
    using System;
    using System.Text.RegularExpressions;

    internal class Program
    {
        static void Main()
        {
            using var sr = new StreamReader("text.txt");
            using var sw = new StreamWriter("output.txt");
            int lineNumber = 1;
            string line = "";

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                int lettersCount = Regex.Matches(line, "[a-zA-Z]").Count;
                int punctuationCount = Regex.Matches(line, "\\p{P}").Count;

                Console.WriteLine($"Line {lineNumber}: {line} ({lettersCount})({punctuationCount})");
                sw.WriteLine($"Line {lineNumber}: {line} ({lettersCount})({punctuationCount})");
                lineNumber++;
            }
        }
    }
}