using ECommerceSystem.Domain.Enum;
using ECommerceSystem.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerceSystem.MVC.ViewModels
{
    public class ProductListViewModel
    {
        public List<ProductModel> Products { get; set; }
        public ProductModel currentProduct { get; set; }
        public List<string> CurrentCategory { get; set; } = new List<string>();
        public List<string> currentProductCategory { get; set; } = new List<string>();
        public List<ProductModel> AllRelatedProductsByCategory { get; set; }
    }
}
