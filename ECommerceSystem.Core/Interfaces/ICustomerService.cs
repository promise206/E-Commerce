using ECommerceSystem.Core.ViewModels;
using ECommerceSystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem.Core.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerModel> Login(LoginViewModel customerDetails);
        Task<CustomerModel> Register(CustomerViewModel customer);
    }
}
