using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCPalindrome.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MVCPalindrome.Controllers
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

        [HttpGet]
        public IActionResult Palindrome()
        {
            Palindrome model = new();
            return View(model);
        }

        [HttpGet]
        public IActionResult ReverseString()
        {
            Palindrome model = new();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ReverseString(Palindrome palindrome)
        {
            string inputString = palindrome.InputString;
            string reverseString = "";

            for (int i = inputString.Length - 1; i >= 1; i--)
            {
                reverseString += inputString[i];
            }

            palindrome.ReverseString = reverseString;

            reverseString = Regex.Replace(reverseString.ToLower(), "[^a-zA-Z0-9]+", "");
            inputString = Regex.Replace(inputString.ToLower(), "[^a-zA-Z0-9]+", "");

            if (reverseString == inputString)
            {
                palindrome.IsPalindrome = true;
                palindrome.Message = @"Success {palindrome.InputString} is a Palindrome";
            }
            else
            {
                palindrome.IsPalindrome = false;
                palindrome.Message = @"Sorry {palindrome.InputString} is NOT a Palindrome";
            }

            return View(palindrome);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}