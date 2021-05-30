using PricingCalculator.BusinessServices.Models;
using PricingCalculator.DataServices.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.BusinessServices.Processors.DiscountProcessors
{
    // this class will be used for calcualting weekly discount
    // this class is derived from BaseDiscountProcessor class and implements the CalculateDiscount method
    public class WeeklyDiscountProcessor:BaseDiscountProcessor<WeeklyDiscountProcessor>
    {
        private readonly IDbContext _dbContext;
        public WeeklyDiscountProcessor(IDbContext DbContext)
        {
            _dbContext = DbContext;
        }

        // implement the PriceDiscount offer
        // apply price discount on items under offer and update item in basket with discount value and discount text.
        public override ShoppingBasketModel CalculateDiscount(ShoppingBasketModel basket)
        {
            foreach (var item in basket.Items)
            {
                var offer = _dbContext.GetOffer(item.Item, "PriceDiscount");
                if (offer != null)
                {
                    if (offer.OfferType == "PriceDiscount" && offer.DiscountPercentage > 0 && item.ItemAmount > 0)
                    {
                        item.ItemDiscount = Math.Round((item.ItemAmount * offer.DiscountPercentage) / 100, 2);
                        item.ItemDiscountText = item.Item + " : " + offer.OfferDescription + " : " + item.ItemDiscount.ToString();
                    }
                }
            }
            // call base class method to update total
            basket = base.UpdateTotal(basket);
            return basket;
        }
                
    }
}
