using ECommerceSystem.Core.Interfaces;
using ECommerceSystem.Core.Utility;
using ECommerceSystem.Domain.Model;
using ECommerceSystem.MVC.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ECommerceSystem.Core.Service
{
    public class ProductService : IProductService
    {
        private readonly string FilePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, @"ECommerceSystem.MVC\wwwroot\ProductImages\");
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductModel> AddProduct(ProductViewModel product)
        {
            try
            {
                product.productImageModel = new List<ProductImageModel>();

                foreach (var file in product.ImageGallery)
                {
                    var gallery = new ProductImageModel()
                    {
                        imageName = await Utility.Utility.uploadImage(file, FilePath),
                        imageSize = file.Length,
                    };

                    product.productImageModel.Add(gallery);
                }

                ProductModel newProduct = new ProductModel()
                {
                    ProductId = Guid.NewGuid().ToString(),
                    productImageModel = product.productImageModel,
                    Category = product.Category.ConvertAll(f => f.ToString()),
                    ActualPrice = CalculatePercentageDiscount(product.Price, product.PercentageOff),
                    ShortDescription = product.ShortDescription,
                    ProductName = product.ProductName,
                    Price = product.Price,
                    InStock = product.Istock,
                    LongDescription = product.LongDescription,
                    Quantity = product.Quantity,
                    PercentageOff = product.PercentageOff
                };
                var getAllProduct = await _productRepository.GetAllProducts();
                List<ProductModel> productList = getAllProduct != null ? getAllProduct : new List<ProductModel>();
                productList.Add(newProduct);
                var store = await _productRepository.AddProduct(productList);
                if (store)
                {
                    return newProduct;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public decimal CalculatePercentageDiscount(decimal price, int percentage)
        {
            decimal perInDecimal = (decimal)percentage / 100;
            decimal savings = (decimal)perInDecimal * price;

            decimal actual = price - savings;
            return actual;
        }
    }
}
