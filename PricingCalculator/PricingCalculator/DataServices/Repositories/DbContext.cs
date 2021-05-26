using PricingCalculator.BusinessServices.Models;
using PricingCalculator.DataServices.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.DataServices.Repositories
{
    public class DbContext : IDbContext
    {
        private readonly ProductRepository _productRepository;
        private readonly SpecialOfferRepository _specialOfferRepository;
        public DbContext()
        {
            _productRepository = new ProductRepository();
            _specialOfferRepository = new SpecialOfferRepository();
        }
        public List<SpecialOffer> GetAllOffers()
        {
            return _specialOfferRepository.GetAll();
        }

        public List<ProductModel> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

        public SpecialOffer GetOffer(string item)
        {
            return _specialOfferRepository.GetOffer(item);
        }

        public ProductModel GetProduct(string item)
        {
            return _productRepository.GetProduct(item);
        }
    }
}
