namespace FastFood.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using FastFood.Data;
    using FastFood.Models;
    using FastFood.Models.Enums;
    using FastFood.DataProcessor.Dto.Import;

    using Newtonsoft.Json;

    public static class Deserializer
	{
		private const string FailureMessage = "Invalid data format.";
		private const string SuccessMessage = "Record {0} successfully imported.";

		public static string ImportEmployees(FastFoodDbContext context, string jsonString)
		{
            var employeesFromJson = JsonConvert.DeserializeObject<EmployeeDto[]>(jsonString);

            var strBuilder = new StringBuilder();

            var validEmployees = new List<Employee>();

            foreach (var employeeDto in employeesFromJson)
            {
                if (!IsValid(employeeDto))
                {
                    strBuilder.AppendLine(FailureMessage);
                    continue;
                }

                var isPositionExisting = context.Positions.Any(p => p.Name == employeeDto.Position);

                if (!isPositionExisting)
                {
                    var currentPosition = new Position()
                    {
                        Name = employeeDto.Position
                    };

                    if (!IsValid(currentPosition))
                    {
                        strBuilder.AppendLine(FailureMessage);
                        continue;
                    }

                    context.Positions.Add(currentPosition);
                    context.SaveChanges();
                }

                var currentEmployee = new Employee()
                {
                    Name = employeeDto.Name,
                    Age = employeeDto.Age,
                    Position = context.Positions.First(p => p.Name == employeeDto.Position)
                };

                validEmployees.Add(currentEmployee);
                strBuilder.AppendLine(string.Format(SuccessMessage, employeeDto.Name));
            }

            context.Employees.AddRange(validEmployees);
            context.SaveChanges();

            var result = strBuilder.ToString().TrimEnd();

            return result;
        }

		public static string ImportItems(FastFoodDbContext context, string jsonString)
		{
            var itemsFromJson = JsonConvert.DeserializeObject<ItemDto[]>(jsonString);

            var strBuilder = new StringBuilder();

            var validItems = new List<Item>();

            foreach (var itemDto in itemsFromJson)
            {
                if (!IsValid(itemDto))
                {
                    strBuilder.AppendLine(FailureMessage);
                    continue;
                }

                var itemExist = validItems.Any(i => i.Name == itemDto.Name);

                if (itemExist)
                {
                    strBuilder.AppendLine(FailureMessage);
                    continue;
                }

                var categoryExist = context.Categories.Any(c => c.Name == itemDto.Category);

                if (!categoryExist)
                {
                    var category = new Category()
                    {
                        Name = itemDto.Category
                    };

                    if (!IsValid(category))
                    {
                        strBuilder.AppendLine(FailureMessage);
                        continue;
                    }

                    context.Categories.Add(category);
                    context.SaveChanges();
                }

                var item = new Item()
                {
                    Name = itemDto.Name,
                    Price = itemDto.Price,
                    Category = context.Categories.First(c => c.Name == itemDto.Category)
                };

                validItems.Add(item);
                strBuilder.AppendLine(string.Format(SuccessMessage, itemDto.Name));
            }

            context.Items.AddRange(validItems);
            context.SaveChanges();

            var result = strBuilder.ToString().TrimEnd();

            return result;
		}

		public static string ImportOrders(FastFoodDbContext context, string xmlString)
		{
            var serializer = new XmlSerializer(typeof(OrderDto[]), new XmlRootAttribute("Orders"));

            var deserializedOrders = (OrderDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            var strBuilder = new StringBuilder();

            var validOrders = new List<Order>();
            var validOrderItems = new List<OrderItem>();

            foreach (var orderDto in deserializedOrders)
            {
                if (!IsValid(orderDto))
                {
                    strBuilder.AppendLine(FailureMessage);
                    continue;
                }

                var orderDateTime = DateTime.ParseExact(orderDto.DateTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                var employee = context.Employees.FirstOrDefault(e => e.Name == orderDto.Employee);
                var itemsExist = orderDto.Items.All(i => context.Items.Any(ci => ci.Name == i.Name));

                if (employee == null || !itemsExist)
                {
                    strBuilder.AppendLine(FailureMessage);
                    continue;
                }

                decimal totalPrice = 0.0m;

                foreach (var item in orderDto.Items)
                {
                    var currentItemPrice = context.Items.First(i => i.Name == item.Name).Price;
                    totalPrice += (decimal)item.Quantity * (decimal)currentItemPrice;
                }

                var currentOrder = new Order()
                {
                    Customer = orderDto.Customer,
                    DateTime = orderDateTime,
                    Employee = employee,
                    Type = Enum.Parse<OrderType>(orderDto.Type),
                    TotalPrice = totalPrice
                };

                validOrders.Add(currentOrder);
                strBuilder.AppendLine($"Order for {orderDto.Customer} on {orderDto.DateTime} added");

                context.Orders.Add(currentOrder);
                context.SaveChanges();

                foreach (var item in orderDto.Items)
                {
                    validOrderItems.Add(new OrderItem()
                    {
                        ItemId = context.Items.First(i => i.Name == item.Name).Id,
                        Quantity = item.Quantity,
                        OrderId = context.Orders.Last().Id
                    });
                }
            }

            //context.Orders.AddRange(validOrders);
            //context.SaveChanges();

            context.OrderItems.AddRange(validOrderItems);
            context.SaveChanges();

            return strBuilder.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);
            return isValid;
        }
    }
}