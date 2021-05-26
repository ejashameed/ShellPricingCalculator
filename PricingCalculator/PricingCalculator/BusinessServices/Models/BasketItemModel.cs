using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.BusinessServices.Models
{
    public class BasketItemModel
    {
        public int ID { get; set; }
        public string Item { get; set; }
        public string ShortDescription { get; set; }
        public double UnitPrice { get; set; }
        public string UnitOfMeasure { get; set; }
        public double ItemAmount { get; set; }
        public double ItemDiscount { get; set; }
        public  string ItemDiscountText { get; set; }
    }
}
