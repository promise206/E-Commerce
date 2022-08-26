using ECommerceSystem.Domain.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ECommerceSystem.Domain.Model
{
    public class ProductModel
    {
        public string ProductId { get; set; }
        [Required]
        [Display(Name ="Product Name")]
        public string ProductName { get; set; }
        public List<ProductImageModel> productImageModel { get; set; }
        [Required]
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }
        [Required]
        [Display(Name = "Long Discription")]
        public string LongDescription { get; set; }
        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        public decimal ActualPrice { get; set; }
        public int  PercentageOff { get; set; }
        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        public bool InStock { get; set; }
        public List<string> Category { get; set; }
    }
}
