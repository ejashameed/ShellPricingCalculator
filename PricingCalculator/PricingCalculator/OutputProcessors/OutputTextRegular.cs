using PricingCalculator.BusinessServices.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PricingCalculator.OutputProcessors
{
    public class OutputTextRegular
    {
        public string OutputText(ShoppingBasketModel basket)
        {
            string output = "";            
            string subTotalToText = "";
            string totalPriceToText = "";

            if (basket.SubTotal >= 1)
            {
                subTotalToText = "Subtotal : " + basket.SubTotal.ToString("C", new CultureInfo("en-GB"));
            }
            else
            {
                subTotalToText = "Subtotal : " + basket.SubTotal.ToString("C", new CultureInfo("en-GB"));
            }
            output = subTotalToText + "\n";

            output += "(No offers available)" + "\n";

            if (basket.FinalTotal >= 1)
            {
                totalPriceToText = "Total Price : " + basket.FinalTotal.ToString("C", new CultureInfo("en-GB"));
            }
            else
            {
                totalPriceToText = "Total Price : " + basket.FinalTotal.ToString("C", new CultureInfo("en-GB"));
            }

            output += totalPriceToText + "\n";

            return output;
        }
    }
}
