namespace CHUSHKA.App.Controllers
{
    using CHUSHKA.Services.Contracts;
    using CHUSHKA.Services.Models.Order;
    using SoftUni.WebServer.Mvc.Attributes.HttpMethods;
    using SoftUni.WebServer.Mvc.Attributes.Security;
    using SoftUni.WebServer.Mvc.Interfaces;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;

    public class OrderController : BaseController
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult All()
        {
            if (!this.IsUserInRoleAdmin())
            {
                return RedirectToHome();
            }

            var allOrders = this.orderService.All();

            this.ViewData["orders"] = this.BuildOrderList(allOrders);

            return View();
        }

        private string BuildOrderList(IEnumerable<OrderListServiceModel> allOrders)
        {
            var builder = new StringBuilder();
            var numberCounter = 1;

            foreach (var order in allOrders)
            {
                var row = $@"<tr>
                                <td>{numberCounter++}</td>
                                <td>{order.Id}</td>
                                <td>{order.ClientUsername}</td>
                                <td>{order.ProductName}</td>
                                <td>{order.OrderedOn.ToString(CultureInfo.InvariantCulture)}</td>
                            </tr>";

                builder.AppendLine(row);
            }

            return builder.ToString();
        }
    }
}
