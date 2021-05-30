using PricingCalculator.BusinessServices.Models;
using PricingCalculator.DataServices.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PricingCalculator.DataServices.Repositories
{
    public class ProductRepository
    {

        public List<ProductModel> GetAll()
        {
            var allProducts = DataSource().ToList();
            var productModelList = new List<ProductModel>();
            if(allProducts.Any() == true)
            {
                foreach (var product in allProducts)
                {
                    productModelList.Add(new ProductModel()
                    {
                        ID = product.ID,
                        Item = product.Item,
                        ShortDescription = product.ShortDescription,
                        UnitPrice = product.UnitPrice,
                        UnitOfMeasure = product.UnitOfMeasure
                    });
                }
            }
            return productModelList;
        }

        public ProductModel GetProduct(string item)
        {
            var product = DataSource().Where(x => x.Item == item).FirstOrDefault();            
            if(product != null) 
            {
                return new ProductModel()
                {
                    ID = product.ID,
                    Item = product.Item,
                    ShortDescription = product.ShortDescription,
                    UnitPrice = product.UnitPrice,
                    UnitOfMeasure = product.UnitOfMeasure
                };
            } 
            else
            {
                return null;
            }
        }

        private List<Product> DataSource()  
        {
            var list = new List<Product>()
            {
                new Product(){ID = 1, Item="Beans", ShortDescription="Beans",UnitPrice=0.65, UnitOfMeasure="can"},
                new Product(){ID = 2, Item="Bread", ShortDescription="Bread",UnitPrice=0.80, UnitOfMeasure="loaf"},
                new Product(){ID = 3, Item="Milk", ShortDescription="Milk",UnitPrice=1.30, UnitOfMeasure="bottle"},
                new Product(){ID = 4, Item="Apples", ShortDescription="Apples",UnitPrice=1.00, UnitOfMeasure="bag"},
            };

            return list;
        }

    }
}
