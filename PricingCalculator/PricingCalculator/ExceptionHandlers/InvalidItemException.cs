using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.ExceptionHandlers
{
    public class InvalidItemException : Exception
    {
        public InvalidItemException()
            :base(String.Format("Invalid Item in basket"))
        {

        }
    }
}
