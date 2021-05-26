using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.BusinessServices.Models
{
    public class SpecialOfferModel
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string OfferType { get; set; }
        public string OfferDescription { get; set; }
        public double DiscountPercentage { get; set; }
        public string CustomerBuysItem { get; set; }
        public int CustomerBuysQuantity { get; set; }
        public string CustomerGetsItem { get; set; }
        public int CustomerGetsDiscount { get; set; }
        public DateTime StartingFrom { get; set; }
        public DateTime EndingOn { get; set; }
        public Boolean IsActive { get; set; }
    }
}
