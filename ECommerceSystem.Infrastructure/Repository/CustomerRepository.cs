using ECommerceSystem.Core.Interfaces;
using ECommerceSystem.Core.Utility;
using ECommerceSystem.Core.ViewModels;
using ECommerceSystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem.Infrastructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IReadWriteToJson _readWriteToJson;
        public readonly string customerFile = "Customer.json";

        public CustomerRepository(IReadWriteToJson readWriteToJson)
        {
            _readWriteToJson = readWriteToJson;
        }

        public async Task<bool> AddCustomer(List<CustomerModel> customers)
        {            
            try
            {
                var store = await _readWriteToJson.WriteAllToJson<List<CustomerModel>>(customers, customerFile);
                if(store)
                    return store;
                else
                    return false;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public Task<List<CustomerModel>> GetAllCustomers() => _readWriteToJson.ReadAllFromJson<CustomerModel>(customerFile);

        public CustomerModel GetCustomerById(string CustomerId)
        {
            throw new NotImplementedException();
        }
    }
}
