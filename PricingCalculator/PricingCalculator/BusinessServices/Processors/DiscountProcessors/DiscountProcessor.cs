using PricingCalculator.BusinessServices.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.BusinessServices.Processors.DiscountProcessors
{
    public class DiscountProcessor : BaseDiscountProcessor
    {
        private readonly WeeklyDiscountProcessor _weeklyDiscountProcessor;
        private readonly BuyXGetYDiscountProcessor _bogoProcessor;
        public DiscountProcessor(WeeklyDiscountProcessor weeklyDiscountProcessor, BuyXGetYDiscountProcessor bogoProcessor)
        {
            _weeklyDiscountProcessor = weeklyDiscountProcessor;
            _bogoProcessor = bogoProcessor;
        }
        public override ShoppingBasketModel CalculateDiscount(ShoppingBasketModel basket)
        {
            _weeklyDiscountProcessor.CalculateWeeklyOffer(basket);
            _bogoProcessor.CalculateBogoDiscount(basket);

            // calculate total discount on items in basket and update basket object
            basket.TotalDiscount = basket.Items.Sum(x => x.ItemDiscount);

            // calculate Final Total and update basket object
            if(basket.SubTotal > basket.TotalDiscount)
            {
                basket.FinalTotal = Math.Round(basket.SubTotal - basket.TotalDiscount,2);
            }
            
            return basket;

        }
    }
}
