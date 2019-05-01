namespace HTTPServer.ByTheCakeApplication.Services
{
    using Contracts;
    using HTTPServer.ByTheCakeApplication.ViewModels;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class ProductService : IProductService
    {
        private string DatabaseFile = @"..\..\..\ByTheCakeApplication\Data\Database.csv";
        private const string ProductDbTemplate = "{0},{1}";

        public void Create(string name, decimal price)
        {
            var productDbEntity = string.Format(ProductDbTemplate, name, price);

            using (var streamWriter = new StreamWriter(DatabaseFile, true))
            {
                streamWriter.WriteLine(productDbEntity);
            }
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            var products = File
                .ReadAllLines(DatabaseFile)
                .Where(line => line.Contains(','))
                .Select(line => line.Split(','))
                .Select(line => new ProductViewModel(line[0], decimal.Parse(line[1])))
                .OrderBy(p => p.Price);

            return products;
        }

        public ProductViewModel Get(string name) 
            => this.GetAll().FirstOrDefault(p => p.Name == name);
    }
}
