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
            string inputJson = File.ReadAllText(@"..\..\..\Datasets\categories-products.json");

            var result = ImportCategoryProducts(dbContext, inputJson);
            Console.WriteLine(result);
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProductDtos = JsonConvert.DeserializeObject<ImportCategoryProductDto[]>(inputJson);

            ICollection<CategoryProduct> categoryProducts = new List<CategoryProduct>();
            foreach (var cpDto in categoryProductDtos)
            {
                CategoryProduct categoryProduct = Mapper.Map<CategoryProduct>(cpDto);
                categoryProducts.Add(categoryProduct);
            }

            context.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }
    }
}