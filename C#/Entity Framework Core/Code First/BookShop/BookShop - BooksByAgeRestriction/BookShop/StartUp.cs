namespace BookShop
{
    using System;
    using System.Linq;
    using System.Text;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            string command = Console.ReadLine().ToLower();
            var result = GetBooksByAgeRestriction(db, command);
            Console.WriteLine(result);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction ageRestriction; 
            bool parseSuccess = Enum.TryParse<AgeRestriction>(command, true, out ageRestriction);
            if (!parseSuccess)
            {
                return String.Empty;
            }

            var books = context
                .Books
                .Where(x => x.AgeRestriction == ageRestriction)
                .OrderBy(x => x.Title)
                .Select(x => x.Title)
                .ToArray();

            return String.Join(Environment.NewLine, books);
        }
    }
}
