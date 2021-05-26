using PricingCalculator.BusinessServices.Models;
using PricingCalculator.BusinessServices.Processors.DiscountProcessors;
using PricingCalculator.BusinessServices.Processors.OrderProcessors;
using PricingCalculator.BusinessServices.Validators;
using PricingCalculator.OutputProcessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.BusinessServices.Handlers
{
    public class OrderRequestHandler : IOrderRequestHandler
    {
        private readonly IOrderProcessor _orderProcessor;
        private readonly IDiscountProcessor _discountProcessor;
        private readonly OrderValidator _orderValidator;
        private readonly IOutputTextFormatter _textFormatter;
        

        public OrderRequestHandler(
                        IOrderProcessor orderProcessor, 
                        IDiscountProcessor discountProcessor, 
                        OrderValidator orderValidator,
                        IOutputTextFormatter textFormatter)
                        
        {
            _orderProcessor = orderProcessor;
            _discountProcessor = discountProcessor;
            _orderValidator = orderValidator;
            _textFormatter = textFormatter;
        }
        public string HandleRequest(OrderItemModel orderItems)
        {
            string outputText = "";

            //check order items are valid
            if (_orderValidator.Validate(orderItems))
            {
                // calculate total price of items in basket
                var basket = _orderProcessor.CalculatePrice(orderItems);

                // check and apply special discount on items under offer
                basket = _discountProcessor.CalculateDiscount(basket);

                //format output 
               outputText = _textFormatter.OutputText(basket);
            }

            return outputText;
        }
    }
}
