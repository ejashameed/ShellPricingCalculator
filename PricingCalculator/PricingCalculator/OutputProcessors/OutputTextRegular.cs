using PricingCalculator.BusinessServices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.OutputProcessors
{
    public class OutputTextRegular
    {
        public string OutputText(ShoppingBasketModel basket)
        {
            string output = "";
            output = "Subtotal : " + basket.SubTotal.ToString() + "\n";
            output += "(No offers available)" + "\n";
            output += "Total Price : " + basket.FinalTotal.ToString();

            return output;
        }
    }
}
