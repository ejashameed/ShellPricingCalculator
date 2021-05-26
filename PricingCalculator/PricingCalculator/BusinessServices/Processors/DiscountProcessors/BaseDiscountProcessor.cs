using PricingCalculator.BusinessServices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.BusinessServices.Processors.DiscountProcessors
{
    public abstract class BaseDiscountProcessor : IDiscountProcessor
    {
        public abstract ShoppingBasketModel CalculateDiscount(ShoppingBasketModel basket);        
    }
}
