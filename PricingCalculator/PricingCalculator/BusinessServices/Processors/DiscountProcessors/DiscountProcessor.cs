//using PricingCalculator.BusinessServices.Models;
//using System;
//using System.Linq;
//using System.Collections.Generic;
//using System.Text;

//namespace PricingCalculator.BusinessServices.Processors.DiscountProcessors
//{
//    public class DiscountProcessor<T> : IDiscountProcessor<T>
//    {
//        private readonly IDiscountProcessor<WeeklyDiscountProcessor> _weeklyDiscountProcessor;
//        private readonly IDiscountProcessor<BuyXGetYDiscountProcessor> _buyXGetYDiscountProcessor;
//        public DiscountProcessor(IDiscountProcessor<WeeklyDiscountProcessor> weeklyDiscountProcessor,
//                        IDiscountProcessor<BuyXGetYDiscountProcessor> buyXGetYDiscountProcessor)
//        {
//            _weeklyDiscountProcessor = weeklyDiscountProcessor;
//            _buyXGetYDiscountProcessor = buyXGetYDiscountProcessor;
//        }
//        public override ShoppingBasketModel CalculateDiscount(ShoppingBasketModel basket)
//        {
//            basket = _weeklyDiscountProcessor.CalculateDiscount(basket);
//            basket = _buyXGetYDiscountProcessor.CalculateDiscount(basket);

//            // calculate total discount on items in basket and update basket object
//            basket.TotalDiscount = basket.Items.Sum(x => x.ItemDiscount);

//            // calculate Final Total and update basket object
//            if(basket.SubTotal > basket.TotalDiscount)
//            {
//                basket.FinalTotal = Math.Round(basket.SubTotal - basket.TotalDiscount,2);
//            }
            
//            return basket;

//        }
//    }
//}
