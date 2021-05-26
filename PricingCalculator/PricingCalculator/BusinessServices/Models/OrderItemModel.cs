using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.BusinessServices.Models
{
    public class OrderItemModel
    {
        public List<String> itemList { get; set; }
        public OrderItemModel()
        {
            itemList = new List<string>();
        }
    }
}
