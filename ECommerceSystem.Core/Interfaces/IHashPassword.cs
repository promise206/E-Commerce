using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceSystem.Core.Interfaces
{
    public interface IHashPassword
    {
        string ComputeSha256Hash(string password);
    }
}
