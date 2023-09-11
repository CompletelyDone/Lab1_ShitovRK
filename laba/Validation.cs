using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace laba
{
    public static class Validation
    {
        private static int minLoginLength = 5;
        private static int minPasswordLength = 7;
        public static bool ValidateLogin(String login)
        {
            if (login.Count() >= minLoginLength)
            {
                if (login.StartsWith("+") && login.Count() == 15)
                {
                    var regex = new Regex(@"\d{1}-\d{3}-\d{3}-\d{4}");
                    var isValidated = regex.IsMatch(login);
                    return isValidated;
                }
                else if (login.Contains('@') && login.Contains('.'))
                {
                    var trimmedEmail = login.Trim();
                    if (trimmedEmail.EndsWith("."))
                    {
                        return false;
                    }
                    try
                    {
                        var addr = new System.Net.Mail.MailAddress(login);
                        return addr.Address == trimmedEmail;
                    }
                    catch
                    {
                        return false;
                    }
                }
                else
                {
                    var latinica = new Regex(@"[A-z]");
                    var numbers = new Regex(@"[0-9]");
                    var chara = new Regex(@"[_]");
                    var isValidated = latinica.IsMatch(login) || numbers.IsMatch(login) || chara.IsMatch(login);
                    return isValidated;
                }
            }
            return false;
        }
        public static bool ValidatePassword(String password)
        {
            var noEng = new Regex(@"[^[A-z]");
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperCase = new Regex(@"[А-Я]+");
            var hasLowerCase = new Regex(@"[а-я]+");
            var hasSpecSymbol = new Regex(@"\W{1}");
            var isValidated = noEng.IsMatch(password) 
                && password.Count() >= minPasswordLength 
                && hasNumber.IsMatch(password)
                && hasUpperCase.IsMatch(password)
                && hasLowerCase.IsMatch(password)
                && hasSpecSymbol.IsMatch(password);
            return isValidated;
        }
    }
}
