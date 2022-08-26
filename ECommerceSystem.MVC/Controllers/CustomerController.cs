using ECommerceSystem.Core.Interfaces;
using ECommerceSystem.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerceSystem.MVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAction(LoginViewModel customerDetails)
        {
            if (ModelState.IsValid)
            {
                var customer = await _customerService.Login(customerDetails);
                if (customer != null)
                {
                    HttpContext.Session.SetString("UserId", customer.CustomerID);
                    HttpContext.Session.SetString("Email", customer.Email);
                    ViewBag.message = "You Logged In Successfully";
                    return RedirectToAction("Index", "Home");
                }
            }
            ViewBag.message = "Invalid Login Details, try Again";
            return View("Login", customerDetails);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAction(CustomerViewModel customer)
        {
            if (ModelState.IsValid)
            {
                var added = await _customerService.Register(customer);
                if (added != null)
                {
                    ViewBag.message = "Registration Successfully";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.message = "Email Already Exist";
                    return View("Register", customer);
                }
            }
            ViewBag.message = "Ohh something went wrong, Try Again!";
            return View("Register", customer);
        }
    }
}
