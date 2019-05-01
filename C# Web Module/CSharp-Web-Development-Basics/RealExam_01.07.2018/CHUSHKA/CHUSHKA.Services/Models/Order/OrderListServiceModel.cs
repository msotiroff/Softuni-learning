namespace CHUSHKA.Services.Models.Order
{
    using CHUSHKA.Common.AutoMapping;
    using CHUSHKA.Models;
    using System;

    public class OrderListServiceModel : IMapWith<Order>
    {
        public string Id { get; set; }
        
        public string ProductName { get; set; }
        
        public string ClientUsername { get; set; }

        public DateTime OrderedOn { get; set; }
    }
}
