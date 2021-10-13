using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPalindrome.Models
{
    public class Palindrome
    {
        //Input String
        [Required]
        public string InputString { get; set; }

        //Reverse the String
        public string ReverseString { get; set; }

        //confirms the word is a palindrome
        public bool IsPalindrome { get; set; }

        //provides confirmation message
        public string Message { get; set; }
    }
}