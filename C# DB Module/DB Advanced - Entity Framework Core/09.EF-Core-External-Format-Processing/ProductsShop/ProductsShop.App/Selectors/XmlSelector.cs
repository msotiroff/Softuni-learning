namespace ProductsShop.App.Selectors
{
    using System.Linq;
    using System.Xml.Linq;
    using ProductsShop.Data;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.IO;
    using System;

    internal class XmlSelector
    {
        internal static string ExportData()
        {
            using (var db = new ProductsShopDbContext())
            {
                string productsInRange = GetProductsInRange(db);
                File.WriteAllText(@"XmlFiles\ExportedXml\ProductsInRange.xml", productsInRange);

                string successfullySoldProducts = GetSuccessfullySoldProducts(db);
                File.WriteAllText(@"XmlFiles\ExportedXml\SuccessfullySoldProducts.xml", successfullySoldProducts);

                string categoriesByProductsCount = GetCategoriesByProductsCount(db);
                File.WriteAllText(@"XmlFiles\ExportedXml\CategoriesByProductsCount.xml", categoriesByProductsCount);

                string usersAndProducts = GetUsersAndProducts(db);
                File.WriteAllText(@"XmlFiles\ExportedXml\UsersAndProducts.xml", usersAndProducts);
            }

            return @"Data exported to directory ~XmlFiles\ExportedXml";
        }

        private static string GetUsersAndProducts(ProductsShopDbContext db)
        {
            var allProducts = db
                .Products
                .Include(p => p.Seller)
                .Where(p => p.BuyerId != null)
                .ToArray();

            var sellersCount = allProducts
                .Select(p => p.Seller)
                .Count();

            var result = new
            {
                usersCount = sellersCount,
                users = allProducts
                    .Select(p => new
                    {
                        firstName = p.Seller.FirstName,
                        lastName = p.Seller.LastName,
                        age = p.Seller.Age,
                        soldProducts = new
                        {
                            count = p.Seller.ProductsSold.Count(),
                            products = p.Seller
                                .ProductsSold
                                .Select(ps => new
                                {
                                    name = ps.Name,
                                    price = ps.Price
                                })
                                .ToArray()
                        }
                    })
                    .ToArray()
            };

            var xmlDoc = new XDocument(new XDeclaration("1.0", "utf-8", null), new XElement("Users", 
                                            new XAttribute("count", result.usersCount)));

            foreach (var seller in result.users)
            {
                var userChild = new XElement("user");

                if (seller.firstName != null)
                {
                    userChild.Add(new XAttribute("first-name", seller.firstName));
                }

                userChild.Add(new XAttribute("last-name", seller.lastName));

                if (seller.age != null)
                {
                    userChild.Add(new XAttribute("age", seller.age));
                }

                var soldProductsChild = new XElement("sold-products",
                                            new XAttribute("count", seller.soldProducts.count));

                foreach (var product in seller.soldProducts.products)
                {
                    soldProductsChild.Add(new XElement("product",
                                            new XAttribute("name", product.name),
                                            new XAttribute("price", product.price)));
                }

                userChild.Add(soldProductsChild);

                xmlDoc.Root.Add(userChild);
            }

            string xmlResult = xmlDoc.Declaration + Environment.NewLine + xmlDoc.ToString();

            return xmlResult;
        }

        private static string GetCategoriesByProductsCount(ProductsShopDbContext db)
        {
            var allCategories = db
                .Categories
                .Include(c => c.Products)
                .Select(c => new
                {
                    name = c.Name,
                    productsCount = c.Products.Count,
                    averagePrice = c.Products.Average(p => p.Product.Price),
                    totalRevenue = c.Products.Sum(p => p.Product.Price)
                })
                .OrderByDescending(a => a.productsCount)
                .ToArray();

            var xmlDoc = new XDocument(new XDeclaration("1.0", "utf-8", null), new XElement("categories"));

            foreach (var category in allCategories)
            {
                xmlDoc.Root.Add(new XElement("category",
                                new XAttribute("name", category.name),
                                new XElement("products-count", category.productsCount),
                                new XElement("average-price", category.averagePrice),
                                new XElement("total-revenue", category.totalRevenue)));
            }

            string result = xmlDoc.Declaration + Environment.NewLine + xmlDoc.ToString();

            return result;
        }

        private static string GetSuccessfullySoldProducts(ProductsShopDbContext db)
        {
            var allSoldProducts = db
                .Products
                .Where(p => p.BuyerId != null)
                .Include(p => p.Seller)
                .Include(p => p.Buyer)
                .ToArray();

            var selectedSellers = allSoldProducts
                .Select(p => new
                {
                    firstName = p.Seller.FirstName,
                    lastName = p.Seller.LastName,
                    soldProducts = p.Seller
                        .ProductsSold
                        .Select(ps => new
                        {
                            name = p.Name,
                            price = p.Price,
                            buyerFirstName = p.Buyer.FirstName,
                            buyerLastName = p.Buyer.LastName
                        })
                        .ToArray()
                })
                .OrderBy(a => a.lastName)
                .ThenBy(a => a.firstName)
                .ToArray();

            var xmlDoc = new XDocument(new XDeclaration("1.0", "utf-8", null), new XElement("users"));

            foreach (var seller in selectedSellers)
            {
                var user = new XElement("user");

                if (seller.firstName != null)
                {
                    user.Add(new XAttribute("first-name", seller.firstName));
                }

                user.Add(new XAttribute("last-name", seller.lastName));

                var soldProducts = new List<XElement>();

                foreach (var product in seller.soldProducts)
                {
                    var childOfSoldProducts = new XElement("product",
                                        new XElement("name", product.name),
                                        new XElement("price", product.price));

                    soldProducts.Add(childOfSoldProducts);
                }

                user.Add(new XElement("sold-products", soldProducts));

                xmlDoc.Root.Add(user);
            }

            string result = xmlDoc.Declaration + Environment.NewLine + xmlDoc.ToString();

            return result;
        }

        private static string GetProductsInRange(ProductsShopDbContext db)
        {
            var allProductsInRange = db
                .Products
                .Where(p => p.Price >= 1000 && p.Price <= 2000 && p.BuyerId != null)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    buyer = $"{p.Buyer.FirstName + " " ?? ""}{p.Buyer.LastName}"
                })
                .OrderByDescending(a => a.price)
                .ToList();

            var xmlDoc = new XDocument(new XDeclaration("1.0", "utf-8", null));
            xmlDoc.Add(new XElement("Products"));

            foreach (var product in allProductsInRange)
            {
                xmlDoc.Root.Add(new XElement("product",
                                    new XAttribute("name", product.name),
                                    new XAttribute("price", product.price),
                                    new XAttribute("buyer", product.buyer)));
            }

            string result = xmlDoc.Declaration + Environment.NewLine + xmlDoc.ToString();

            return result;
        }
    }
}