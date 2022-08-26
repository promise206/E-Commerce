using ECommerce.Models;
using ECommerceSystem.Core.Interfaces;
using ECommerceSystem.Domain.Model;
using ECommerceSystem.MVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public HomeController(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index()
        {
            ProductListViewModel productListViewModel = new ProductListViewModel();
            productListViewModel.Products = await _productRepository.GetAllProducts() != null? await _productRepository.GetAllProducts(): new List<ProductModel>();
            productListViewModel.CurrentCategory = _categoryRepository.GetAllCategories();
            return View(productListViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
