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
//Handles the service request call from the Client Application
    public class OrderRequestHandler : IOrderRequestHandler
    {
        private readonly IOrderProcessor _orderProcessor;
        private readonly IDiscountProcessor<WeeklyDiscountProcessor> _weeklyDiscountProcessor;
        private readonly IDiscountProcessor<BuyXGetYDiscountProcessor> _buyXGetYDiscountProcessor;
        private readonly OrderValidator _orderValidator;
        private readonly IOutputTextFormatter _textFormatter;
        

        //create instances of dependent classes using .Net core DI container
        public OrderRequestHandler(
                        IOrderProcessor orderProcessor,
                        IDiscountProcessor<WeeklyDiscountProcessor> weeklyDiscountProcessor,
                        IDiscountProcessor<BuyXGetYDiscountProcessor> buyXGetYDiscountProcessor,
                        OrderValidator orderValidator,
                        IOutputTextFormatter textFormatter)
                        
        {
            _orderProcessor = orderProcessor;
            _weeklyDiscountProcessor = weeklyDiscountProcessor;
            _buyXGetYDiscountProcessor = buyXGetYDiscountProcessor;
            _orderValidator = orderValidator;
            _textFormatter = textFormatter;
        }

        //methos that handles the client call to calculate the total price of items in basket
        public string HandleRequest(OrderItemModel orderItems)
        {
            string outputText = "";

            //check order items in basket are valid
            if (_orderValidator.Validate(orderItems))
            {
                // calculate total price of items in basket
                var basket = _orderProcessor.CalculatePrice(orderItems);

                // check and apply weekly discount on items under offer
                basket = _weeklyDiscountProcessor.CalculateDiscount(basket);

                // check and apply BuyXGetY discount 
                basket = _buyXGetYDiscountProcessor.CalculateDiscount(basket);

                //format output 
               outputText = _textFormatter.ApplyTextFormatting(basket);
            }

            return outputText;
        }
    }
}
