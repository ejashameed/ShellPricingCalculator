using PricingCalculator.BusinessServices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.OutputProcessors
{
    public interface IOutputTextFormatter
    {
        public string ApplyTextFormatting(ShoppingBasketModel basket);
    }
}
