using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.ExceptionHandlers
{
    public class ItemNotFoundException: Exception
    {
       
        public ItemNotFoundException(string item)
            :base(String.Format("Invalid Item : {0}",item))
        {

        }
    }
}
