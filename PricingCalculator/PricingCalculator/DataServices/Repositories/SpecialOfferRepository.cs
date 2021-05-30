using PricingCalculator.DataServices.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.DataServices.Repositories
{
    public class SpecialOfferRepository
    {
        public List<SpecialOffer> GetAll()
        {
            return DataSource().ToList();
        }

        public SpecialOffer GetOffer(string item)
        {
            return DataSource().Where(x => x.Item == item && x.IsActive == true).FirstOrDefault();
        }

        public SpecialOffer GetOffer(string item, string offerType)
        {
            return DataSource().Where(x => x.Item == item && x.OfferType == offerType && x.IsActive == true).FirstOrDefault();
        }

        private List<SpecialOffer> DataSource()
        {
            return new List<SpecialOffer>()
              {
                new SpecialOffer(){ID = 1,ProductID = 4, Item = "Apples",OfferType="PriceDiscount",OfferDescription = "Apples 10% off",DiscountPercentage=10,StartingFrom=DateTime.Today, EndingOn = DateTime.Today.AddDays(7), IsActive = true},
                new SpecialOffer(){ID = 2,ProductID = 2, Item = "Bread",OfferType = "BuyXGetY",OfferDescription = "Buy 2 Beans Get Half Bread",CustomerBuysItem="Beans",CustomerBuysQuantity = 2,CustomerGetsItem ="Bread",CustomerGetsDiscount =50,StartingFrom=DateTime.Today, EndingOn = DateTime.Today.AddDays(7), IsActive = true},
              };
        }
    }
}
