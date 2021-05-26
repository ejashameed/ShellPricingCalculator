using PricingCalculator.BusinessServices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.BusinessServices.Processors.OrderProcessors
{
    public abstract class BaseOrderProcessor : IOrderProcessor
    {
        public abstract ShoppingBasketModel CalculatePrice(OrderItemModel orderItems);        
    }
}
