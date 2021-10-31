using System;
using System.Collections.Generic;
using System.Text;

namespace Discount_System
{
    class DiscountSystemHelper
    {
        public static List<DiscountSystem> GetDiscountRules()
        {
            return new List<DiscountSystem>
            {
                new DiscountSystem{ ProductId =1, BuyItem = 2, DiscountItem = 1 }
            };
        }
    }
}
