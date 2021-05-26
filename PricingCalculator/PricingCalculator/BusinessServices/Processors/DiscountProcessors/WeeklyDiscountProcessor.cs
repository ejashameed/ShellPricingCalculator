﻿using PricingCalculator.BusinessServices.Models;
using PricingCalculator.DataServices.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.BusinessServices.Processors.DiscountProcessors
{
    public class WeeklyDiscountProcessor
    {
        private readonly IDbContext _dbContext;
        public WeeklyDiscountProcessor(IDbContext DbContext)
        {
            _dbContext = DbContext;
        }

        public ShoppingBasketModel CalculateWeeklyOffer(ShoppingBasketModel basket)
        {
            foreach (var item in basket.Items)
            {
               var offer = _dbContext.GetOffer(item.Item);
               if(offer != null)
               {
                    if (offer.OfferType == "PriceDiscount" && offer.DiscountPercentage > 0)
                    {
                        item.ItemDiscount = Math.Round((item.ItemAmount * offer.DiscountPercentage) / 100, 2);
                        item.ItemDiscountText = item.Item + " : " + offer.OfferDescription + " : " + item.ItemDiscount.ToString();
                    }
               }                
            }

            return basket;
        }
    }
}