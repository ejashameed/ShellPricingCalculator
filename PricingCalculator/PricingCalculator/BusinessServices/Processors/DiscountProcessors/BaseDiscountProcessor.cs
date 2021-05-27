using PricingCalculator.BusinessServices.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.BusinessServices.Processors.DiscountProcessors
{
    public abstract class BaseDiscountProcessor<T> : IDiscountProcessor<T>
    {
        public abstract ShoppingBasketModel CalculateDiscount(ShoppingBasketModel basket);    
        public ShoppingBasketModel UpdateTotal(ShoppingBasketModel basket)
        {
            // calculate total discount on items in basket and update basket object
            basket.TotalDiscount = basket.Items.Sum(x => x.ItemDiscount);

            // calculate Final Total and update basket object
            if (basket.SubTotal > basket.TotalDiscount)
            {
                basket.FinalTotal = Math.Round(basket.SubTotal - basket.TotalDiscount, 2);
            }

            return basket;
        }
    }
}
