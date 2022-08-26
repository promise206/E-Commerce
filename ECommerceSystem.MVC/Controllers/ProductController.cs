using ECommerceSystem.Core.Interfaces;
using ECommerceSystem.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerceSystem.MVC.Controllers
{
    public class ProductController : Controller
    {
       
        private readonly IProductRepository _productRepository;
        private readonly IProductService _productService;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository, IProductService productService)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _productService = productService;
        }

        public async Task<IActionResult> ProductList(string id)
        {
            ProductListViewModel productListViewModel = new ProductListViewModel();
            productListViewModel.Products = await _productRepository.GetAllProducts();
            productListViewModel.currentProduct = await _productRepository.GetProductById(id);
            productListViewModel.CurrentCategory = _categoryRepository.GetAllCategories();
            productListViewModel.currentProductCategory = productListViewModel.currentProduct.Category;
            productListViewModel.AllRelatedProductsByCategory = await _productRepository.GetProductsByCategory(id);
            return View(productListViewModel);
        }

        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> StoreProduct(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                if (product.ImageGallery != null)
                {
                    var storeProduct = await _productService.AddProduct(product);
                    if (storeProduct != null)
                    {
                        ViewBag.message = "Added Successfully";
                        return RedirectToAction("AddProduct");
                    }
                    else
                    {
                        ViewBag.message = "Product Insert UnSuccessful";
                        return View("AddProduct", product);
                    } 
                }
            }
            ViewBag.message = "Fill In The Details Properly";
            return View("AddProduct", product);
        }
    }
}
