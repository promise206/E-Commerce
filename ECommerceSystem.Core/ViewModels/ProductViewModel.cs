using ECommerceSystem.Domain.Enum;
using ECommerceSystem.Domain.Model;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceSystem.MVC.ViewModels
{
    public class ProductViewModel
    {
        [Required(ErrorMessage ="Enter Product Name")]
        [StringLength(50,ErrorMessage ="Product Name Exceeded")]
        public string ProductName { get; set; }
        [Required(ErrorMessage ="Select Product Images")]
        public IFormFileCollection ImageGallery { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Short Desc Exceeded")]
        public string ShortDescription { get; set; }
        [Required(ErrorMessage ="Enter Long Description")]
        public string LongDescription { get; set; }
        [Required(ErrorMessage ="Enter Price")]
        [Display(Name ="Price")]
        public decimal Price { get; set; }
        [Required(ErrorMessage ="Enter %Discount")]
        public int PercentageOff { get; set; }
        [Required(ErrorMessage ="Select Category")]
        public Categories Categories { get; set; }
        
        [Required(ErrorMessage ="Enter Quantity")]
        public int Quantity { get; set; }
        public List<Categories> Category { get; set; }
        public bool Istock { get; set; } = true;
        public List<ProductImageModel> productImageModel { get; set; }
    }
}
