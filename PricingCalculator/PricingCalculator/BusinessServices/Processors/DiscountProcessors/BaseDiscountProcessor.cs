using PricingCalculator.BusinessServices.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.BusinessServices.Processors.DiscountProcessors
{
    // This is the base class for calculating discount on items in basket
    // Any discount class or new classes in future will derive from this base class and implement the CalculateDiscoount method.
    public abstract class BaseDiscountProcessor<T> : IDiscountProcessor<T>
    {
        public abstract ShoppingBasketModel CalculateDiscount(ShoppingBasketModel basket);    
        
        // this method will calculate the total price of items in basket and update the SubTotal, FinalToal & TotalDiscount
        public virtual ShoppingBasketModel UpdateTotal(ShoppingBasketModel basket)
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
