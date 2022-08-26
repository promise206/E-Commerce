using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceSystem.Core.Interfaces
{
    public interface IValidate
    {
        bool isValidAccountNumber(string accountNumber);
        bool isValidAmount(double amount);
        bool isValidEmail(string inputEmail);
        bool isValidName(string inputName);
        bool isValidPassword(string inputPassword);
    }
}
