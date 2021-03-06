using PricingCalculator.BusinessServices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.OutputProcessors
{
    public class BaseTextFormatter : IOutputTextFormatter
    {
        private readonly OutputTextRegular _regularTextFormatter;
        private readonly OutputTextWithOffer _offerTextFormatter;
        public BaseTextFormatter(OutputTextRegular regularTextFormatter,OutputTextWithOffer offerTextFormatter)
        {
            _offerTextFormatter = offerTextFormatter;
            _regularTextFormatter = regularTextFormatter;
        }
        public virtual string ApplyTextFormatting(ShoppingBasketModel basket)
        {
            // formatted output
            string outputText = "";

            if (basket.TotalDiscount > 0)
            {
                // template for printing with discount
                outputText = _offerTextFormatter.OutputText(basket);
            }
            else
            {
                // tempalte for printing without discount text
                outputText = _regularTextFormatter.OutputText(basket);
            }
            return outputText;
        }
    }
}
