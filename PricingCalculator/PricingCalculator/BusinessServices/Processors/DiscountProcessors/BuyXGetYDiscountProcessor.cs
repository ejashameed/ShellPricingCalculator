using PricingCalculator.BusinessServices.Models;
using PricingCalculator.DataServices.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.BusinessServices.Processors.DiscountProcessors
{
    // this class will be used for calcualting Buy One Get One kind of discount
    // this class is derived from BaseDiscountProcessor class and implements the CalculateDiscount method
    public class BuyXGetYDiscountProcessor:BaseDiscountProcessor<BuyXGetYDiscountProcessor>
    {
        private readonly IDbContext _dbContext;
        public BuyXGetYDiscountProcessor(IDbContext DbContext)
        {
            _dbContext = DbContext;
        }
       
        public override ShoppingBasketModel CalculateDiscount(ShoppingBasketModel basket)
        {
            foreach (var item in basket.Items)
            {
                // check already discount is applied on item. - asssumption is that only one discount at a time allowed
                // for example, if 2 cans of beans and 2 loafs of bread added in basket, only one loaf of bread should get half discount
                if (basket.Items.Where(i => i.Item == item.Item).Sum(x => x.ItemDiscount) <= 0)
                {
                    // check which item in basket is under offer for BuyXGetY type
                    var offer = _dbContext.GetOffer(item.Item, "BuyXGetY");
                    if (offer != null)
                    {
                        if (offer.OfferType == "BuyXGetY") // check the discount type
                        {
                            if (basket.Items.Where(x => x.Item == offer.CustomerBuysItem).Count() >= offer.CustomerBuysQuantity)
                            {
                                item.ItemDiscount = Math.Round((item.ItemAmount * offer.CustomerGetsDiscount) / 100, 2);
                                item.ItemDiscountText = item.Item + " : " + offer.OfferDescription + " : " + item.ItemDiscount.ToString();
                            }
                        }
                    }
                }
            }
            basket = base.UpdateTotal(basket);
            return basket;            
        }
    }
}
