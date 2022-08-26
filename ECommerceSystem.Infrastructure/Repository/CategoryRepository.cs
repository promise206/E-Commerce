using ECommerceSystem.Core.Interfaces;
using ECommerceSystem.Domain.Enum;
using ECommerceSystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerceSystem.Infrastructure.Repository
{
    public class CategoryRepository: ICategoryRepository
    {
        public List<string> GetAllCategories() => ((Categories[]) Enum.GetValues(typeof(Categories))).Select(c => c.ToString()).ToList();
    }
}
