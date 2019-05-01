using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsShop.Data
{
    internal class Configuration
    {
        public static string ConnectionString => 
            @"Server=DESKTOP-LRMHUDK\SQLEXPRESS;Database=ProductsShop;Integrated Security=true";
    }
}
