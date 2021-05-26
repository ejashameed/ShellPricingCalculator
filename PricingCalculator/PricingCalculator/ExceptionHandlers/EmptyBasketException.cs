using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.ExceptionHandlers
{
    public class EmptyBasketException : Exception
    {
        
        public EmptyBasketException()
            : base(String.Format("No item found in the basket"))
        { 
        }
    }
}
