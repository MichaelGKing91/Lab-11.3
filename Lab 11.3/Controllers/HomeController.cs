using Lab_11._3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_11._3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult RegistrationForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            // Add Validation here
            if (user.password != user.passcheck)
            {
                return Content("Your passwords did not match!" +
                    " Your profile has not been created.");
            }
            string emailVal = @"^\w{1,36}@\w{1,36}\.\w{2,36}$";
            Regex myRegex = new Regex(emailVal);
            if (!myRegex.IsMatch(user.email))
            {
                return Content("Your email was invalid!" +
                    " Your profile has not been created.");
            }
            string phoneVal = @"^[0-9]{1,2}\([0-9]{3}\)[0-9]{3}-[0-9]{4}$";
            myRegex = new Regex(phoneVal);
            if (!myRegex.IsMatch(user.phone))
            {
                return Content("Your phone number was invalid!" +
                    " \nYour profile has not been created. \nPlease use the format: #(###)###-#### ");
            }
            return View(user);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
