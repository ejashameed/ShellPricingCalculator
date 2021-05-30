using PricingCalculator.BusinessServices.Models;
using PricingCalculator.DataServices.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.DataServices.Repositories
{
    public interface IDbContext
    {
        public List<ProductModel> GetAllProducts();
        public ProductModel GetProduct(string item);
        public List<SpecialOffer> GetAllOffers();
        public SpecialOffer GetOffer(string item);
        public SpecialOffer GetOffer(string item, string offerType);
    }
}
