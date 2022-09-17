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
            string inputJson = File.ReadAllText(@"..\..\..\Datasets\products.json");

            var result = ImportProducts(dbContext, inputJson);
            Console.WriteLine(result);
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var productDtos = JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson);

            ICollection<Product> products = new List<Product>();
            foreach (var pDto in productDtos)
            {
                Product product = Mapper.Map<Product>(pDto);
                products.Add(product);
            }

            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }
    }
}