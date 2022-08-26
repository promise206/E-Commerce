using ECommerceSystem.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem.Core.Utility
{
    public class Utility : IHashPassword
    {
        public string ComputeSha256Hash(string password)
        {
            //Create a SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {

                //ComputeHas - return byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                //Convert byte array to string 
                StringBuilder bulder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    bulder.Append(bytes[i].ToString("x2"));
                }
                return bulder.ToString();

            }
        }

        public static async Task<string> uploadImage(IFormFile imagefile, string path)
        {
            string fileName = Guid.NewGuid().ToString() + "_" + imagefile.FileName;
            string filePath = Path.Combine(path, fileName);
            await imagefile.CopyToAsync(new FileStream(filePath, FileMode.Create));

            return fileName;
        }

    }
}
