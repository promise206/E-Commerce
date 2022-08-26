using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem.Core.Interfaces
{
    public interface IReadWriteToJson
    {
        Task<bool> WriteAllToJson<T>(T model, string jsonFile);
        Task<List<T>> ReadAllFromJson<T>(string jsonFile);
    }
}
