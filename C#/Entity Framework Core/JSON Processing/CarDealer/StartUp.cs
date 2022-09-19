namespace CarDealer
{
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.DTO;
    using CarDealer.Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        static IMapper mapper;

        public static void Main()
        {
            var context = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //Console.WriteLine("Database deleted");
            //context.Database.EnsureCreated();
            //Console.WriteLine("Database created");

            var inputJsonSuppliers = File.ReadAllText("../../../Datasets/suppliers.json");
            var inputJsonParts = File.ReadAllText("../../../Datasets/parts.json");
            var inputJsonCars = File.ReadAllText("../../../Datasets/cars.json");
            var inputJsonCustomers = File.ReadAllText("../../../Datasets/customers.json");
            var inputJsonSales = File.ReadAllText("../../../Datasets/sales.json");

            var result = GetCarsWithTheirListOfParts(context);
            Console.WriteLine(result);
        }

        // Import
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            InitializMapper();

            var supplierDtos = JsonConvert.DeserializeObject<IEnumerable<SupplierDto>>(inputJson);
            var suppliers = mapper.Map<IEnumerable<Supplier>>(supplierDtos);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            InitializMapper();

            var partDtos = JsonConvert.DeserializeObject<IEnumerable<PartDto>>(inputJson)
                .Where(x => context.Suppliers.Any(s => s.Id == x.SupplierId)).ToArray();
            var parts = mapper.Map<IEnumerable<Part>>(partDtos);

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            InitializMapper();

            var customersDtos = JsonConvert.DeserializeObject<IEnumerable<CustomerDto>>(inputJson);
            var customers = mapper.Map<IEnumerable<Customer>>(customersDtos);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            InitializMapper();

            var saleDtos = JsonConvert.DeserializeObject<IEnumerable<SaleDto>>(inputJson);
            var sales = mapper.Map<IEnumerable<Sale>>(saleDtos);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }

        // Export
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .Select(x => new
                {
                    x.Name,
                    BirthDate = x.BirthDate.ToString("dd/MM/yyyy"),
                    x.IsYoungDriver
                })
                .ToList();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make == "Toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(x => new
                {
                    x.Id,
                    x.Make,
                    x.Model,
                    x.TravelledDistance
                })
                .ToArray();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    PartsCount = x.Parts.Count()
                })
                .ToArray();

            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(x => new
                {
                    car = new
                    {
                        x.Make,
                        x.Model,
                        x.TravelledDistance
                    },
                    parts = x.PartCars.Select(p => new
                    {
                        p.Part.Name,
                        Price = p.Part.Price.ToString("F2")
                    })
                })
                .ToArray();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        private static void InitializMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });
            mapper = config.CreateMapper();
        }

    }
}