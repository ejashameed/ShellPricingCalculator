using PricingCalculator.BusinessServices.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PricingCalculator.OutputProcessors
{
    public class OutputTextWithOffer
    {
        public string OutputText(ShoppingBasketModel basket)
        {
            string output = "";
            string pound = "£";
            string pence = "p";
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


            foreach (var item in basket.Items)
            {
                if (item.ItemDiscount > 0)
                {
                    if (item.ItemDiscount >= 1)
                    {
                        output += pound + item.ItemDiscountText + "\n";
                    }
                    else
                    {
                        output += item.ItemDiscountText + pence + "\n";
                    }

                }
            }

            if (basket.FinalTotal >= 1)
            {
                totalPriceToText = "Total : " + basket.FinalTotal.ToString("C", new CultureInfo("en-GB"));
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

