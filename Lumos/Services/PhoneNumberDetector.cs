using Lumos.Models;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Lumos.Services
{
    public class PhoneNumberDetector : IPhoneNumberDetector
    {
        private static readonly List<string> Patterns = new List<string>
    {
        @"\+?\d[\d -]{8,}\d", // General pattern for numbers with optional country code
        @"\(?\d{2,4}\)?[\d -]{6,10}\d", // With parentheses for area codes
        @"\b(ONE|TWO|THREE|FOUR|FIVE|SIX|SEVEN|EIGHT|NINE|ZERO)\b", // English words
        @"\b(एक|दो|तीन|चार|पांच|छह|सात|आठ|नौ|शून्य)\b", // Hindi words
        @"\b(ONE|TWO|THREE|FOUR|FIVE|SIX|SEVEN|EIGHT|NINE|ZERO|एक|दो|तीन|चार|पांच|छह|सात|आठ|नौ|शून्य)\b" // Mixed
    };

        public string DetectPhoneNumbers(string phoneNumber)
        {
            var detectedNumbers = new List<PhoneNumber>();
            string response = null;
            if (!string.IsNullOrEmpty(phoneNumber))
            {
                response = Regex.Replace(phoneNumber, @"[-()+]", "");
                string cleanedInput = Regex.Replace(phoneNumber, @"[^\w\s]", "");
            }
            return response;
        }

        private static string DetermineFormat(string number)
        {
            if (number.Contains("+"))
                return "True";
            if (number.Contains("("))
                return "True";
            if (Regex.IsMatch(number, @"^\d+$"))
                return "True";
            if (Regex.IsMatch(number, @"\b(ONE|TWO|THREE|FOUR|FIVE|SIX|SEVEN|EIGHT|NINE|ZERO)\b", RegexOptions.IgnoreCase))
                return "True";
            if (Regex.IsMatch(number, @"\b(एक|दो|तीन|चार|पांच|छह|सात|आठ|नौ|शून्य)\b"))
                return "True";
            if (Regex.IsMatch(number, @"\b(ONE|TWO|THREE|FOUR|FIVE|SIX|SEVEN|EIGHT|NINE|ZERO|एक|दो|तीन|चार|पांच|छह|सात|आठ|नौ|शून्य)\b", RegexOptions.IgnoreCase))
                return "True";
            return "False";
        }

       
    }

}
