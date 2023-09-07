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
                    if (login[2].Equals('-') && login[6].Equals('-') && login[10].Equals('-'))
                    {
                        foreach (char c in login)
                        {
                            if (!char.IsDigit(c))
                            {
                                if (c != '+')
                                {
                                    if (c != '-')
                                    {
                                        return false;
                                    }
                                    return false;
                                }
                                return false;
                            }
                        }
                        return true;
                    }
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
            var regex = new Regex(@"[^[A-z]");
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperCase = new Regex(@"[А-Я]+");
            var hasLowerCase = new Regex(@"[а-я]+");
            var isValidated = regex.IsMatch(password) 
                && password.Count() >= minPasswordLength 
                && hasNumber.IsMatch(password)
                && hasUpperCase.IsMatch(password)
                && hasLowerCase.IsMatch(password);
            return isValidated;
        }
    }
}
