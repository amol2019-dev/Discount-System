using System;
using System.Collections.Generic;
using System.Linq;

namespace Discount_System
{
    class Program
    {
        static void Main(string[] args)
        {
            var apple = ProductHelper.GetProducts().FirstOrDefault(x => x.ProductId == 1);
            var mango = ProductHelper.GetProducts().FirstOrDefault(x => x.ProductId == 2);
            var orange = ProductHelper.GetProducts().FirstOrDefault(x => x.ProductId == 3);

            Console.WriteLine("Welcome to Discount System:");
            Order order = new Order() { OrderId = 1, OrderDateTime = DateTime.Now };
            
            order.OrderItem.Add(new OrderItem() { OrderId = 1, ProductId = apple.ProductId, Quantity = 7, PriceApplied = apple.Price });
            order.OrderItem.Add(new OrderItem() { OrderId = 1, ProductId = mango.ProductId, Quantity = 1, PriceApplied = mango.Price });

            Console.WriteLine($"Order No: {order.OrderId} Order DateTime: {order.OrderDateTime}");

            decimal total = 0;
            decimal totalDiscount = 0;
            foreach (var item in order.OrderItem)
            {
                Console.Write($"Product: {item.ProductId} ");
                Console.Write($"Quantity: {item.Quantity} ");
                Console.Write($"Price: {item.PriceApplied} ");
                Console.Write($"Discount: {item.Discount} ");
                Console.WriteLine($"Cost: {item.Quantity * item.PriceApplied} ");
                total += item.Quantity * item.PriceApplied;
                totalDiscount += item.Discount;
            }
            Console.WriteLine($"Total: {total} Discount: {totalDiscount} Billing Amount: {total - totalDiscount}");

        }
    }

    class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public string Code { get; set; }
        public decimal Price { get; set; }
    }

    class Order
    {
        public Order()
        {
            OrderItem = new List<OrderItem>();
        }
        public int OrderId { get; set; }
        public DateTime OrderDateTime { get; set; }

        public List<OrderItem> OrderItem { get; set; }
    }

    public class OrderItem
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public decimal PriceApplied { get; set; }

        public int Quantity { get; set; }

        public decimal Discount 
        {
            get
            {
                var discountRule = DiscountSystemHelper.GetDiscountRules().FirstOrDefault(x => x.ProductId == 1);
                if (discountRule == null)
                    return 0;

                decimal discount = 0;

                if(Quantity >= (discountRule.BuyItem + discountRule.DiscountItem))
                {
                    discount = (Quantity / (discountRule.BuyItem + discountRule.DiscountItem)) * PriceApplied;
                }

                return discount;
            }
            
        }
    }

    class DiscountSystem
    {
        public int ProductId { get; set; }
        public int  BuyItem { get; set; }
        public int DiscountItem { get; set; }
    }
}
