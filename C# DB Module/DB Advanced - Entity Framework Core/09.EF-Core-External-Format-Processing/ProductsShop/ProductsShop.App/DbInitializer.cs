namespace ProductsShop.App
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using System.Collections.Generic;

    using Newtonsoft.Json;
    using Microsoft.EntityFrameworkCore;

    using ProductsShop.Data;
    using ProductsShop.Models;

    public class DbInitializer
    {
        private static Random rnd = new Random();

        internal static string ResetDatabase()
        {
            using (var db = new ProductsShopDbContext())
            {
                db.Database.EnsureDeleted();

                db.Database.Migrate();

                db.Database.EnsureCreated();
            }

            return "Database reset successfull";
        }

        internal static string SeedDataFromJson()
        {
            var usersFromJson = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(@"JsonFiles\users.json"));

            var categoriesFromJson = JsonConvert.DeserializeObject<List<Category>>(File.ReadAllText(@"JsonFiles\categories.json"));

            var productsFromJson = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(@"JsonFiles\products.json"));

            ResetDatabase();

            using (var db = new ProductsShopDbContext())
            {
                SeedUsers(usersFromJson, db);

                SeedCategories(categoriesFromJson, db);

                SeedProducts(productsFromJson, db);

                GenerateCategoryForEachProduct(db);
            }

            return "Seeding completed successfully!";
        }

        internal static string SeedDataFromXml()
        {
            var usersFromXml = File.ReadAllText(@"XmlFiles\users.xml");
            List<User> allUsers = GetUsersFromXml(usersFromXml);

            var categoriesFromXml = File.ReadAllText(@"XmlFiles\categories.xml");
            List<Category> allCategories = GetCategoriesFromXml(categoriesFromXml);

            var productsFromXml = File.ReadAllText(@"XmlFiles\products.xml");
            List<Product> allProducts = GetProductsFromXml(productsFromXml);

            ResetDatabase();

            using (var db = new ProductsShopDbContext())
            {
                SeedUsers(allUsers, db);

                SeedCategories(allCategories, db);

                SeedProducts(allProducts, db);

                GenerateCategoryForEachProduct(db);

            }

            return "Seeding completed successfully!";
        }

        private static List<Product> GetProductsFromXml(string productsFromXml)
        {
            var xmlDoc = XDocument.Parse(productsFromXml);

            var elements = xmlDoc.Root.Elements();

            var allProducts = new List<Product>();

            foreach (var element in elements)
            {
                string productName = element.Element("name").Value;
                decimal productPrice = decimal.Parse(element.Element("price").Value);

                var currentProduct = new Product()
                {
                    Name = productName,
                    Price = productPrice
                };

                allProducts.Add(currentProduct);
            }

            return allProducts;
        }

        private static List<Category> GetCategoriesFromXml(string categoriesFromXml)
        {
            var xmlDoc = XDocument.Parse(categoriesFromXml);

            var elements = xmlDoc.Root.Elements();

            var allcategories = new List<Category>();

            foreach (var element in elements)
            {
                string categoryName = element.Element("name").Value;

                var currentCategory = new Category()
                {
                    Name = categoryName
                };

                allcategories.Add(currentCategory);
            }

            return allcategories;
        }

        private static List<User> GetUsersFromXml(string usersFromXml)
        {
            var xmlDoc = XDocument.Parse(usersFromXml);

            var elements = xmlDoc.Root.Elements();

            var allUsers = new List<User>();

            foreach (var element in elements)
            {
                string firstName = element.Attribute("firstName")?.Value;
                string lastName = element.Attribute("lastName").Value;
                int? age = null;

                if (element.Attribute("age")?.Value != null)
                {
                    age = int.Parse(element.Attribute("age").Value);
                }

                var currentUser = new User()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age
                };

                allUsers.Add(currentUser);
            }

            return allUsers;
        }

        private static void GenerateCategoryForEachProduct(ProductsShopDbContext db)
        {
            var allProductsIds = db
                .Products
                .Select(p => p.Id)
                .ToList();

            var allCategoriesIds = db
                .Categories
                .Select(c => c.Id)
                .ToList();

            var categoryProducts = new List<CategoryProduct>();

            for (int i = 0; i < allProductsIds.Count; i++)
            {
                var currentCategoryProduct = new CategoryProduct()
                {
                    ProductId = allProductsIds[i],
                    CategoryId = allCategoriesIds[rnd.Next(0, allCategoriesIds.Count)]
                };

                categoryProducts.Add(currentCategoryProduct);
            }

            db.CategoryProducts.AddRange(categoryProducts);
            db.SaveChanges();
        }

        private static void SeedProducts(List<Product> allProducts, ProductsShopDbContext db)
        {
            var allUsersIds = db
                .Users
                .Select(u => u.Id)
                .ToList();

            var updatedProducts = new List<Product>();

            for (int i = 0; i < allProducts.Count; i++)
            {
                var currentProduct = allProducts[i];

                if (i % 3 == 0)
                {
                    currentProduct.SellerId = GetRandomSellerId(allUsersIds);

                    var sellerId = currentProduct.SellerId;

                    currentProduct.BuyerId = GetRandomBuyerId(allUsersIds, sellerId);
                }
                else
                {
                    currentProduct.SellerId = GetRandomSellerId(allUsersIds);
                }

                updatedProducts.Add(currentProduct);
            }

            db.Products.AddRange(updatedProducts);
            db.SaveChanges();
        }

        private static int GetRandomBuyerId(List<int> allUsersIds, int sellerId)
        {
            var selectedUsers = allUsersIds
                .Where(id => id != sellerId)
                .ToList();

            var randomUserId = selectedUsers[rnd.Next(0, selectedUsers.Count)];

            return randomUserId;
        }

        private static int GetRandomSellerId(List<int> allUsersIds)
        {
            var randomUserId = allUsersIds[rnd.Next(0, allUsersIds.Count)];

            return randomUserId;
        }

        private static void SeedCategories(List<Category> allCategories, ProductsShopDbContext db)
        {
            db.Categories.AddRange(allCategories);
            db.SaveChanges();
        }

        private static void SeedUsers(List<User> allUsers, ProductsShopDbContext db)
        {
            db.Users.AddRange(allUsers);
            db.SaveChanges();
        }
    }
}
