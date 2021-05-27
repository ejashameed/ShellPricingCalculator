using PricingCalculator.BusinessServices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.BusinessServices.Processors.DiscountProcessors
{
    public interface IDiscountProcessor<T>
    {
        public abstract ShoppingBasketModel CalculateDiscount(ShoppingBasketModel basket);
    }
}
    