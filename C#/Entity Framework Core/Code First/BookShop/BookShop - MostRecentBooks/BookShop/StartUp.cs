namespace BookShop
{
    using BookShop.Initializer;
    using BookShop.Models.Enums;
    using Data;

    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            var result = GetMostRecentBooks(db);
            Console.WriteLine(result);

        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var sb = new StringBuilder();

            var categories = context.Categories
                .Select(x => new
                {
                    x.Name,
                    Books = x.CategoryBooks
                        .OrderByDescending(cb => cb.Book.ReleaseDate.Value)
                        .Select(cb => new 
                        {
                            cb.Book.Title,
                            cb.Book.ReleaseDate.Value.Year,
                        })
                        .Take(3)
                })
                .OrderBy(x => x.Name)
                .ToArray();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.Name}");
                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
