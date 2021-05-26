using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.BusinessServices.Models
{
    public class ShoppingBasketModel
    {
        public ShoppingBasketModel()
        {
            Items = new List<BasketItemModel>();
            SubTotal = 0;
            FinalTotal = 0;
            ID = Guid.NewGuid().ToString();
        }
        public string ID { get; set; }
        public double SubTotal { get; set; }

        public double TotalDiscount { get; set; }
        public double FinalTotal { get; set; }
        public List<BasketItemModel> Items { get; set; }

    }
}
