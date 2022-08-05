using System;
using System.Collections.Generic;
using System.IO;

using ProductShop.Data;
using ProductShop.DTOs.User;
using ProductShop.Models;

using AutoMapper;
using Newtonsoft.Json;
using ProductShop.DTOs.Product;
using ProductShop.DTOs.Category;
using ProductShop.DTOs.CategoryProduct;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile(typeof(ProductShopProfile)));
            ProductShopContext dbContext = new ProductShopContext();
            string inputJson = File.ReadAllText(@"..\..\..\Datasets\categories.json");

            var result = ImportCategories(dbContext, inputJson);
            Console.WriteLine(result);
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categoryDtos = JsonConvert.DeserializeObject<ImportCategoryDto[]>(inputJson);

            ICollection<Category> categories = new List<Category>();
            foreach (var cDto in categoryDtos)
            {
                if (cDto.Name == null) 
                {
                    continue;
                }
                Category category = Mapper.Map<Category>(cDto);
                categories.Add(category);
            }

            context.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }
    }
}