namespace FastFood.DataProcessor
{
    using System.Linq;
    using System.Xml.Linq;

    using FastFood.Data;

    using Newtonsoft.Json;

    public class Serializer
	{
		public static string ExportOrdersByEmployee(FastFoodDbContext context, string employeeName, string orderType)
		{
            var employee = context.Employees
                .Where(e => e.Name == employeeName && e.Orders.Any(o => o.Type.ToString() == orderType))
                .Select(e => new
                {
                    Name = e.Name,
                    Orders = e.Orders
                    .Where(o => o.Type.ToString() == orderType)
                    .Select(o => new
                    {
                        Customer = o.Customer,
                        Items = o.OrderItems
                        .Select(oa => new
                        {
                            Name = oa.Item.Name,
                            Price = oa.Item.Price,
                            Quantity = oa.Quantity
                        })
                        .ToArray(),
                        TotalPrice = o.OrderItems.Sum(oa => oa.Quantity * oa.Item.Price)
                    })
                    .OrderByDescending(o => o.TotalPrice)
                    .ThenByDescending(o => o.Items.Count())
                    .ToArray(),
                    TotalMade = e.Orders.Sum(o => o.OrderItems.Sum(oa => oa.Quantity * oa.Item.Price))
                })
                .First();

            var result = JsonConvert.SerializeObject(employee, Formatting.Indented);

            return result;
		}

		public static string ExportCategoryStatistics(FastFoodDbContext context, string categoriesString)
		{
            var inputCategories = categoriesString.Split(",");

            var categories = context.Categories
                  .Where(c => inputCategories.Contains(c.Name))
                  .Select(c => new
                  {
                      CategoryName = c.Name,
                      MostPopularItem = c.Items
                      .OrderByDescending(i => i.Price * i.OrderItems.Sum(oa => oa.Quantity))
                      .Select(mp => new
                      {
                          Name = mp.Name,
                          TotalMade = mp.Price * mp.OrderItems.Sum(oa => oa.Quantity),
                          TimesSold = mp.OrderItems.Sum(mpoa => mpoa.Quantity)
                      })
                      .First()
                  })
                  .OrderByDescending(a => a.MostPopularItem.TotalMade)
                  .ThenByDescending(a => a.MostPopularItem.TimesSold)
                  .ToArray();

            var xmlDoc = new XDocument(new XElement("Categories"));

            foreach (var category in categories)
            {
                var currentCategory = new XElement("Category",
                                        new XElement("Name", category.CategoryName),
                                        new XElement("MostPopularItem",
                                            new XElement("Name", category.MostPopularItem.Name),
                                            new XElement("TotalMade", category.MostPopularItem.TotalMade),
                                            new XElement("TimesSold", category.MostPopularItem.TimesSold)));

                xmlDoc.Root.Add(currentCategory);
            }

            var result = xmlDoc.ToString();

            return result;
		}
	}
}