using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerceSystem.Core.ViewModels
{
    public class CustomerViewModel 
    {
        [Required(ErrorMessage ="Enter Input First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter Last Name")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Invaid Email")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string PasswordAgain { get; set; }
        [Required]
        [StringLength(11, ErrorMessage ="Invalid Number")]
        public string Mobile { get; set; }
        [Required(ErrorMessage ="Select Image")]
        public IFormFile ImageUrl { get; set; }
        [Required(ErrorMessage ="Enter Address")]
        public string ShippingAddress { get; set; }
        public string ImageName { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
