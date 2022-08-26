using ECommerceSystem.Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ECommerceSystem.Core.Utility
{
    public class ReadWriteToJson : IReadWriteToJson
    {
        private readonly string filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, @"ECommerceSystem.Infrastructure\Data\");
        public async Task<bool> WriteAllToJson<T>(T model, string jsonFile)
        {
            try
            {
                string json = JsonConvert.SerializeObject(model);
                await File.WriteAllTextAsync(filePath + jsonFile, json);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<T>> ReadAllFromJson<T>(string jsonFile)
        {
            var readText = await File.ReadAllTextAsync(filePath + jsonFile);
            return JsonConvert.DeserializeObject<List<T>>(readText);
        }
    }
}
