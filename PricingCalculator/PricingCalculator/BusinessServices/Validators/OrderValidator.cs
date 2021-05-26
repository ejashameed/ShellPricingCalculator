using PricingCalculator.BusinessServices.Models;
using PricingCalculator.DataServices.Repositories;
using PricingCalculator.ExceptionHandlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.BusinessServices.Validators
{
    public class OrderValidator
    {
        private readonly IDbContext _dbContext;
        public OrderValidator(IDbContext DbContext)
        {
            _dbContext = DbContext;
        }
        public Boolean Validate(OrderItemModel orderItems)
        {

            //check item count in the basket
            if(orderItems.itemList.Count <= 0)
            {
                throw new EmptyBasketException();
            }

            foreach (var item in orderItems.itemList)
            {
                // if item in the basket is empty
                if(String.IsNullOrEmpty(item))
                {
                    throw new InvalidItemException();
                }
                // if null or whitespace
                if (String.IsNullOrWhiteSpace(item))
                {
                    throw new InvalidItemException();
                }

                var productItem = _dbContext.GetProduct(item.ToString());
                if(productItem == null)
                {
                    throw new ItemNotFoundException(item.ToString());
                }
            }
            return true;
        }
    }
}
