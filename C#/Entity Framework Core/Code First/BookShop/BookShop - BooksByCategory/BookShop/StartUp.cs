namespace BookShop
{
    using BookShop.Initializer;
    using BookShop.Models.Enums;
    using Data;

    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            string input = Console.ReadLine();
            var result = GetBooksByCategory(db, input);
            Console.WriteLine(result);
        }

        public static string GetBooksByCategory(BookShopContext context, string input) 
        {
            var categories = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLower())
                .ToArray();

            var books = context.Books
                .Where(x => x.BookCategories
                    .Any(x => categories.Contains(x.Category.Name.ToLower())))
                .Select(x => x.Title)
                .OrderBy(Title => Title)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }
    }
}
