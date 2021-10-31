using System;
using System.Collections.Generic;
using System.Text;

namespace Discount_System
{
    class ProductHelper
    {
        public static List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product{ ProductId = 1, ProductName = "Apple", Price = 100, Code = "AA" },
                new Product{ ProductId = 2, ProductName = "Mango", Price = 200, Code = "BB" },
                new Product{ ProductId = 3, ProductName = "Orange", Price = 300,  Code = "CC" }
            };
        }
    }
}
