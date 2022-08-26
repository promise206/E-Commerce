using ECommerceSystem.Domain.Model;
using ECommerceSystem.MVC.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem.Core.Interfaces
{
    public interface IProductService
    {
        decimal CalculatePercentageDiscount(decimal price, int percentage);
        Task<ProductModel> AddProduct(ProductViewModel product);

    }
}
