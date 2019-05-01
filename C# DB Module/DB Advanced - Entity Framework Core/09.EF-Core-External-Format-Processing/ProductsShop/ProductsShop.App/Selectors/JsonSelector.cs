namespace ProductsShop.App.Selectors
{
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;
    using ProductsShop.Data;
    using Microsoft.EntityFrameworkCore;

    internal class JsonSelector
    {
        internal static string ExportData()
        {
            using (var db = new ProductsShopDbContext())
            {
                GetProductsInRange(db);

                GetSuccessfullySoldProducts(db);

                GetCategoriesByProductsCount(db);

                GetUsersAndProducts(db);
            }

            return @"Data exported to directory ~JsonFiles\ExportedJsons";
        }

        private static void GetUsersAndProducts(ProductsShopDbContext db)
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

            string stringResult = JsonConvert.SerializeObject(result, Formatting.Indented);

            File.WriteAllText(@"JsonFiles\ExportedJsons\UsersAndProducts.json", stringResult);
        }

        private static void GetCategoriesByProductsCount(ProductsShopDbContext db)
        {
            var allCategories = db
                .Categories
                .Include(c => c.Products)
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.Products.Count,
                    averagePrice = c.Products.Average(p => p.Product.Price),
                    totalRevenue = c.Products.Sum(p => p.Product.Price)
                })
                .OrderBy(a => a.category)
                .ToArray();

            string categories = JsonConvert.SerializeObject(allCategories, Formatting.Indented);

            File.WriteAllText(@"JsonFiles\ExportedJsons\CategoriesByProductCount.json", categories);
        }

        private static void GetSuccessfullySoldProducts(ProductsShopDbContext db)
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

            string successfullySoldProducts = JsonConvert.SerializeObject(selectedSellers, Formatting.Indented);

            File.WriteAllText(@"JsonFiles\ExportedJsons\SoldProducts.json", successfullySoldProducts);
        }

        private static void GetProductsInRange(ProductsShopDbContext db)
        {
            var allProductsInRange = db
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = $"{p.Seller.FirstName + " " ?? ""}{p.Seller.LastName}"
                })
                .OrderByDescending(a => a.price)
                .ToList();

            string products = JsonConvert.SerializeObject(allProductsInRange, Formatting.Indented);

            File.WriteAllText(@"JsonFiles\ExportedJsons\ProductsInRange.json", products);
        }

    }
}