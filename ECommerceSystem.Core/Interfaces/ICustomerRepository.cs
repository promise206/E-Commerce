using ECommerceSystem.Core.ViewModels;
using ECommerceSystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem.Core.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<CustomerModel>> GetAllCustomers();
        Task<bool> AddCustomer(List<CustomerModel> customers);
        CustomerModel GetCustomerById(string CustomerId);
    }
}
