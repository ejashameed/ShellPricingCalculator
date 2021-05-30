using PricingCalculator.BusinessServices.Models;
using PricingCalculator.DataServices.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PricingCalculator.DataServices.Repositories
{
    //custom implementation of DBContext - in-memory list is used to load the data
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

        public SpecialOffer GetOffer(string item, string offerType)
        {
            return _specialOfferRepository.GetOffer(item,offerType);
        }

        public ProductModel GetProduct(string item)
        {
            return _productRepository.GetProduct(item);
        }
    }
}
