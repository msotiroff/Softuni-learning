namespace Airport.App.Models.Shopping
{
    using Airport.Models;
    using System.Collections.Generic;

    public class ShoppingCart
    {
        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
