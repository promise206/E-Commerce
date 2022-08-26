using ECommerceSystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceSystem.Core.Interfaces
{
    public interface ICategoryRepository
    {
        List<string> GetAllCategories();
    }
}
