namespace ProductShop
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using AutoMapper;
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

            var result = ImportCategoryProducts(context, inputJsonCP);
            Console.WriteLine(result);
        }


        // Import (JSON - C# objects)
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