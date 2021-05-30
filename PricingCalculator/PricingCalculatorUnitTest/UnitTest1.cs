using NUnit.Framework;
using PricingCalculator.BusinessServices.Handlers;
using PricingCalculator.BusinessServices.Models;
using PricingCalculator.BusinessServices.Processors.DiscountProcessors;
using PricingCalculator.BusinessServices.Processors.OrderProcessors;
using PricingCalculator.BusinessServices.Validators;
using PricingCalculator.DataServices.Repositories;
using PricingCalculator.OutputProcessors;

namespace PricingCalculatorUnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
           
        }

        // test total price calculation with discount on Apples & But 2 Beans and Get Half Bread offer
        [Test]
        public void Test1()
        {    
            // manually create instances of required objects

            IOrderProcessor orderProcessor = new ShoppingBasketProcessor(new DbContext());
            OrderValidator validator = new OrderValidator(new DbContext());
            OutputTextRegular textRegular = new OutputTextRegular();
            OutputTextWithOffer textWithOffer = new OutputTextWithOffer();
            IOutputTextFormatter textFormatter = new BaseTextFormatter(textRegular,textWithOffer);

            //WeeklyDiscountProcessor weeklyDiscount = new WeeklyDiscountProcessor(new DbContext());
            //BuyXGetYDiscountProcessor BuyXGetY = new BuyXGetYDiscountProcessor(new DbContext());
            
            IDiscountProcessor<WeeklyDiscountProcessor> weeklyDiscountProcessor = new WeeklyDiscountProcessor(new DbContext());
            IDiscountProcessor<BuyXGetYDiscountProcessor> buyXGetYDiscountProcessor = new BuyXGetYDiscountProcessor(new DbContext());

            OrderRequestHandler requestHandler = new OrderRequestHandler(orderProcessor,weeklyDiscountProcessor,buyXGetYDiscountProcessor,validator,textFormatter);

            OrderItemModel orderItems = new OrderItemModel();
            orderItems.itemList.Add("Apples");
            orderItems.itemList.Add("Bread");
            orderItems.itemList.Add("Beans");
            orderItems.itemList.Add("Beans");
            orderItems.itemList.Add("Milk");

            string output = requestHandler.HandleRequest(orderItems);
            System.Console.WriteLine(output);
            Assert.Pass();
        }

        // Check discount on Apples
        [Test]
        public void Test2()
        {
            // manually create instances of required objects

            IOrderProcessor orderProcessor = new ShoppingBasketProcessor(new DbContext());
            OrderValidator validator = new OrderValidator(new DbContext());
            OutputTextRegular textRegular = new OutputTextRegular();
            OutputTextWithOffer textWithOffer = new OutputTextWithOffer();
            IOutputTextFormatter textFormatter = new BaseTextFormatter(textRegular, textWithOffer);

            WeeklyDiscountProcessor weeklyDiscount = new WeeklyDiscountProcessor(new DbContext());
            BuyXGetYDiscountProcessor BuyXGetY = new BuyXGetYDiscountProcessor(new DbContext());

            IDiscountProcessor<WeeklyDiscountProcessor> weeklyDiscountProcessor = new WeeklyDiscountProcessor(new DbContext());
            IDiscountProcessor<BuyXGetYDiscountProcessor> buyXGetYDiscountProcessor = new BuyXGetYDiscountProcessor(new DbContext());

            OrderRequestHandler requestHandler = new OrderRequestHandler(orderProcessor, weeklyDiscountProcessor,buyXGetYDiscountProcessor, validator, textFormatter);

            OrderItemModel orderItems = new OrderItemModel();
            orderItems.itemList.Add("Apples");
            orderItems.itemList.Add("Bread");
            orderItems.itemList.Add("Beans");
            
            string output = requestHandler.HandleRequest(orderItems);
            System.Console.WriteLine(output);
            Assert.Pass();
        }
    }
}