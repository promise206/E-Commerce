using ECommerceSystem.Core.Interfaces;
using ECommerceSystem.Core.Service;
using ECommerceSystem.Core.Utility;
using ECommerceSystem.Domain.Model;
using ECommerceSystem.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem.Infrastructure.Repository
{
    public class ProductRepository: IProductRepository
    {
        private readonly IReadWriteToJson _readWriteToJson;
        public readonly string _productFile = "Products.json";

        public ProductRepository(ICategoryRepository categoryRepository, IReadWriteToJson readWriteToJson)
        {
            _readWriteToJson = readWriteToJson;
        }
        public Task<List<ProductModel>> GetAllProducts() => _readWriteToJson.ReadAllFromJson<ProductModel>(_productFile);
        public IEnumerable<ProductModel> BestSaleProduct { get; }

        public async Task<bool> AddProduct(List<ProductModel> productList)
        {
            try
            {
                var store = await _readWriteToJson.WriteAllToJson<List<ProductModel>>(productList, _productFile);
                if (store)
                {
                    return store;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ProductModel> GetProductById(string ProductId)
        {
            var getAllProducts = await GetAllProducts();
            return getAllProducts.FirstOrDefault(x => x.ProductId.Equals(ProductId));
        }
        
        public async Task<List<ProductModel>> GetProductsByCategory(string ProductId)
        {
            var allProductsById = await GetProductById(ProductId);
            var currentProductCategory = allProductsById.Category;

            var getAllProduct = await GetAllProducts();
            List<ProductModel> listOfProductByCategory = new List<ProductModel>();
            foreach(var product in getAllProduct)
            {
                var productExist = (currentProductCategory.Any(x => product.Category.Any(y => y == x)));
                if (productExist)
                {
                    listOfProductByCategory.Add(product);
                }
            }

            return listOfProductByCategory;
        }
    }
}
