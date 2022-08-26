using ECommerceSystem.Core.Interfaces;
using ECommerceSystem.Core.Utility;
using ECommerceSystem.Core.ViewModels;
using ECommerceSystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ECommerceSystem.Core.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly string FilePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, @"ECommerceSystem.MVC\wwwroot\CustomerImages\");

        private readonly ICustomerRepository _customerRepository;
        private readonly IHashPassword _hashPassword;
        public CustomerService(ICustomerRepository customerRepository, IHashPassword hashPassword)
        {
            _customerRepository = customerRepository;
            _hashPassword = hashPassword;
        }

        public async Task<CustomerModel> Register(CustomerViewModel customer)
        {
            if (await DoesEmailExist(customer.Email.ToLower()))
                return null;

            string fileName = await Utility.Utility.uploadImage(customer.ImageUrl, FilePath);

            CustomerModel newCustomer = new CustomerModel()
            {
                CustomerID = Guid.NewGuid().ToString(),
                LastName = customer.LastName,
                FirstName = customer.FirstName,
                ImageName = fileName,
                Password = _hashPassword.ComputeSha256Hash(customer.Password),
                ShippingAddress = customer.ShippingAddress,
                CreatedDate = customer.CreatedDate,
                Mobile = customer.Mobile,
                Email = customer.Email.ToLower()
            };
            var getAllCustomer = await _customerRepository.GetAllCustomers();
            List<CustomerModel> customerList = getAllCustomer != null ? getAllCustomer : new List<CustomerModel>();
            customerList.Add(newCustomer);
            var added = await _customerRepository.AddCustomer(customerList);
            if (added)
            {
                return newCustomer;
            }
            else
            {
                return null;
            }
        }

        public async Task<CustomerModel> Login(LoginViewModel customerDetails)
        {
            var allCustomers = await _customerRepository.GetAllCustomers();
            foreach (var customer in allCustomers)
            {
                if (customer.Email.Equals(customerDetails.Email.ToLower()) && customer.Password.Equals(_hashPassword.ComputeSha256Hash(customerDetails.Password)))
                {
                    return customer;
                }
            }
            return null;
        }

        public async Task<bool> DoesEmailExist(string email)
        {
            var allCustomers = await _customerRepository.GetAllCustomers();
            return allCustomers.Exists(x => x.Email.Equals(email));
        }

    }
}
