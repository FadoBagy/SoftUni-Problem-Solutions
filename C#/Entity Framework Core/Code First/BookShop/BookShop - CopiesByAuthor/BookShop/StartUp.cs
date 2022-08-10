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

            var result = CountCopiesByAuthor(db);
            Console.WriteLine(result);

        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var books = context.Authors
                .Select(x => new
                {
                    AuthorName = x.FirstName + " " + x.LastName,
                    BookCopiesCount =  x.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(x => x.BookCopiesCount)
                .ToArray();

            return String.Join(Environment.NewLine, books.Select(x => $"{x.AuthorName} - {x.BookCopiesCount}"));
        }
    }
}
