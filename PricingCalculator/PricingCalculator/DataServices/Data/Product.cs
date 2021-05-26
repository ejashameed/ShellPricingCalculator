using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.DataServices.Data
{
    public class Product
    {
        public int ID { get; set; }
        public string Item { get; set; }
        public string ShortDescription { get; set; }        
        public double UnitPrice { get; set; }
        public string UnitOfMeasure { get; set; }
    }
}
