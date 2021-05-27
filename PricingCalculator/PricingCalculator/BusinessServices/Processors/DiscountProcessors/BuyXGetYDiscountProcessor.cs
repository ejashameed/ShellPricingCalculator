using PricingCalculator.BusinessServices.Models;
using PricingCalculator.DataServices.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.BusinessServices.Processors.DiscountProcessors
{
    public class BuyXGetYDiscountProcessor:BaseDiscountProcessor<BuyXGetYDiscountProcessor>
    {
        private readonly IDbContext _dbContext;
        public BuyXGetYDiscountProcessor(IDbContext DbContext)
        {
            _dbContext = DbContext;
        }

        public ShoppingBasketModel CalculateBogoDiscount(ShoppingBasketModel basket)
        {
            foreach (var item in basket.Items)
            {
                var offer = _dbContext.GetOffer(item.Item);
                if (offer != null)
                {
                    if (offer.OfferType == "BuyXGetY")
                    {
                        if (basket.Items.Where(x => x.Item == offer.CustomerBuysItem).Count() >= offer.CustomerBuysQuantity)
                        {
                            item.ItemDiscount = Math.Round((item.ItemAmount * offer.CustomerGetsDiscount) / 100, 2);
                            item.ItemDiscountText = item.Item + " : " + offer.OfferDescription + " : " + item.ItemDiscount.ToString();
                        }
                    }
                }

            }
            return basket;
        }
        
        public override ShoppingBasketModel CalculateDiscount(ShoppingBasketModel basket)
        {
            foreach (var item in basket.Items)
            {
                var offer = _dbContext.GetOffer(item.Item);
                if (offer != null)
                {
                    if (offer.OfferType == "BuyXGetY")
                    {
                        if (basket.Items.Where(x => x.Item == offer.CustomerBuysItem).Count() >= offer.CustomerBuysQuantity)
                        {
                            item.ItemDiscount = Math.Round((item.ItemAmount * offer.CustomerGetsDiscount) / 100, 2);
                            item.ItemDiscountText = item.Item + " : " + offer.OfferDescription + " : " + item.ItemDiscount.ToString();
                        }
                    }
                }

            }
            basket = base.UpdateTotal(basket);
            return basket;            
        }
    }
}
