namespace ProductShop
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    using ProductShop.Data;
    using ProductShop.DataTransferObjects;
    using ProductShop.Models;

    public class StartUp
    {
        static IMapper mapper;

        public static void Main()
        {
            var context = new ProductShopContext();
            //context.Database.EnsureDeleted();
            //Console.WriteLine("Database deleted");
            //context.Database.EnsureCreated();
            //Console.WriteLine("Database created");

            var inputJsonUsers = File.ReadAllText("../../../Datasets/users.json");
            var inputJsonProducts = File.ReadAllText("../../../Datasets/products.json");
            var inputJsonCategories = File.ReadAllText("../../../Datasets/categories.json");
            var inputJsonCP = File.ReadAllText("../../../Datasets/categories-products.json");

            var result = GetUsersWithProducts(context);
            Console.WriteLine(result);
        }

        // Imports (JSON - C# objects)
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            InitializMapper();

            var usersDtos = JsonConvert.DeserializeObject<IEnumerable<UserDTO>>(inputJson);

            var users = mapper.Map<IEnumerable<User>>(usersDtos);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            InitializMapper();

            var productDtos = JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(inputJson);
            var products = mapper.Map<IEnumerable<Product>>(productDtos);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            InitializMapper();

            var categoryDtos = JsonConvert.DeserializeObject<IEnumerable<CategoryDto>>(inputJson).Where(x => x.Name != null);
            var categories = mapper.Map<IEnumerable<Category>>(categoryDtos);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            InitializMapper();

            var categoryProductDtos = JsonConvert.DeserializeObject<IEnumerable<CategoryProductDto>>(inputJson);
            var categoryProducts = mapper.Map<IEnumerable<CategoryProduct>>(categoryProductDtos);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count()}";
        }

        // Exports (C# objects - JSON)
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Select(x => new {
                    name = x.Name,
                    price = x.Price,
                    seller = $"{x.Seller.FirstName} {x.Seller.LastName}"
                })
                .ToArray();

            var result = JsonConvert.SerializeObject(products, Formatting.Indented);
            return result;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Count() > 0)
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(x => new {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold
                        .Where(p => p.BuyerId != null)
                        .Select(p => new {
                            name = p.Name,
                            price = p.Price,
                            buyerFirstName = p.Buyer.FirstName,
                            buyerLastName = p.Buyer.LastName,
                        })
                        .ToArray()
                })
                .ToArray();

            Console.WriteLine(users.Count());

            var result = JsonConvert.SerializeObject(users, Formatting.Indented);
            return result;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(x => x.CategoryProducts.Count())
                .Select(x => new {
                    category = x.Name,
                    productsCount = x.CategoryProducts.Count(),
                    averagePrice = x.CategoryProducts.Average(cp => cp.Product.Price).ToString("F2"),
                    totalRevenue = x.CategoryProducts.Sum(cp => cp.Product.Price).ToString("F2")
                })
                .ToArray();

            var result = JsonConvert.SerializeObject(categories, Formatting.Indented);
            return result;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Include(x => x.ProductsSold)
                .ToArray()
                .Where(x => x.ProductsSold.Any(p => p.BuyerId != null))
                .OrderByDescending(x => x.ProductsSold.Count())
                .Select(x => new {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    age = x.Age,
                    soldProducts = new {
                        count = x.ProductsSold.Where(p => p.BuyerId != null).Count(),
                        products = x.ProductsSold
                            .Where(p => p.BuyerId != null)
                            .Select(p => new {
                                name = p.Name,
                                price = p.Price,
                            }).ToArray()
                    }
                })
                .ToArray();

            var result = new
            {
                usersCount = users.Count(),
                users
            };

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            };

            return JsonConvert.SerializeObject(result, Formatting.Indented, jsonSerializerSettings);
        }

        private static void InitializMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
            mapper = config.CreateMapper();
        }
    }
}