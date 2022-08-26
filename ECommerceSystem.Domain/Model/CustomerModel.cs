using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ECommerceSystem.Domain.Model
{
    public class CustomerModel
    {
        public string CustomerID { get; set; }
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Mobile { get; set; }

        public string ImageName { get; set; }
        [Required]
        public string ShippingAddress { get; set; }
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
