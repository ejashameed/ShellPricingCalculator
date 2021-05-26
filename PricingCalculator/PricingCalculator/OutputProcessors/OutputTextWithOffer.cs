using PricingCalculator.BusinessServices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.OutputProcessors
{
    public class OutputTextWithOffer
    {
        public string OutputText(ShoppingBasketModel basket)
        {
            string output = "";
            output = "Subtotal : " + basket.SubTotal.ToString() + "\n";
            foreach (var item in basket.Items)
            {
                if(item.ItemDiscount > 0)
                {
                    output += item.ItemDiscountText + "\n";
                }                
            }           
            output += "Total : " + basket.FinalTotal.ToString();

            return output;
        }
    }
}
