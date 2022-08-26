using ECommerceSystem.Domain.Model;
using ECommerceSystem.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetAllProducts();
        IEnumerable<ProductModel> BestSaleProduct { get; }
        Task<ProductModel> GetProductById(string ProductId);
        Task<bool> AddProduct(List<ProductModel> productList);
        Task<List<ProductModel>> GetProductsByCategory(string ProductId);
    }
}
