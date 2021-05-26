using PricingCalculator.BusinessServices.Models;
using PricingCalculator.DataServices.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using PricingCalculator.BusinessServices.Processors.DiscountProcessors;

namespace PricingCalculator.BusinessServices.Processors.OrderProcessors
{
    public class ShoppingBasketProcessor : BaseOrderProcessor
    {
        private readonly IDbContext _dbContext;
        
        public ShoppingBasketProcessor(IDbContext DbContext)
        {
            _dbContext = DbContext;           
        }

        public override ShoppingBasketModel CalculatePrice(OrderItemModel orderItems)
        {
            /*** 
            1. create an instance of shopping basket and 
            add order items with product details to shopping basket object
            2. calculate sub total of items in basket
            3. Check any offer on any items and apply discounts if any
            ***/
            try
            {
                var basket = new ShoppingBasketModel();
                int loopCount = 1;
                foreach (var item in orderItems.itemList)
                {
                    var productItem = _dbContext.GetProduct(item.ToString());
                    var basketItem = new BasketItemModel()
                    {
                        ID = loopCount,
                        Item = productItem.Item,
                        ShortDescription = productItem.ShortDescription,
                        UnitPrice = productItem.UnitPrice,
                        UnitOfMeasure = productItem.UnitOfMeasure,
                        ItemAmount = (1 * productItem.UnitPrice)
                    };

                    basket.Items.Add(basketItem);
                    loopCount += 1;
                }

                // calculate subtotal of items in basket and update basket object
                basket.SubTotal = basket.Items.Sum(x => x.ItemAmount);

                // Final total same as subtotal before applying any discounts
                basket.FinalTotal = basket.SubTotal;
                basket.TotalDiscount = 0;

                return basket;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
    }
}
