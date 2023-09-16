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
        
        public static (bool, string) Validate(string login, string password, string verifyPassword)
        {
            (bool, string) returningMessage = (false, "");
            bool isValidatedLogin = false;
            bool isValidatedPassword = false;
            if (login.Count() >= minLoginLength)
            {
                if (login.StartsWith("+") && login.Count() == 15)
                {
                    var regex = new Regex(@"\d{1}-\d{3}-\d{3}-\d{4}");
                    var isValidatedPhone = regex.IsMatch(login);
                    if(isValidatedPhone)
                    {
                        isValidatedLogin = true;
                    }
                    else
                    {
                        returningMessage.Item2 += "Phone number isn't correct\n";
                    }
                }
                else if (login.Contains('@') && login.Contains('.'))
                {
                    var trimmedEmail = login.Trim();
                    if (trimmedEmail.EndsWith("."))
                    {
                        returningMessage.Item1 = false;
                    }
                    try
                    {
                        var addr = new System.Net.Mail.MailAddress(login);
                        if(addr.Address == trimmedEmail)
                        {
                            isValidatedLogin = true;
                        }
                        else
                        {
                            returningMessage.Item2 += "Email isn't correct\n";
                        }
                    }
                    catch
                    {
                        isValidatedLogin = true;
                    }
                }
                else
                {
                    var latinica = new Regex(@"[A-z]");
                    if(!latinica.IsMatch(login))
                    {
                        returningMessage.Item2 += "No latinica in login\n";
                    }
                    var numbers = new Regex(@"[0-9]");
                    if (!numbers.IsMatch(login))
                    {
                        returningMessage.Item2 += "No numbers in login\n";
                    }
                    var chara = new Regex(@"[_]");
                    if (!chara.IsMatch(login))
                    {
                        returningMessage.Item2 += "No special symbols in login\n";
                    }
                    isValidatedLogin = latinica.IsMatch(login) || numbers.IsMatch(login) || chara.IsMatch(login);
                    if(isValidatedLogin)
                    {
                        returningMessage.Item1 = true;
                    }
                    else
                    {
                        returningMessage.Item1 = false;
                    }
                }
            }

            var noEng = new Regex(@"[^[A-z]");
            if (!noEng.IsMatch(password))
            {
                returningMessage.Item2 += "No eng in password\n";
            }
            var hasNumber = new Regex(@"[0-9]+");
            if (!hasNumber.IsMatch(password))
            {
                returningMessage.Item2 += "No numbers in password\n";
            }
            var hasUpperCase = new Regex(@"[А-Я]+");
            if (!hasUpperCase.IsMatch(password))
            {
                returningMessage.Item2 += "No uppercase in password\n";
            }
            var hasLowerCase = new Regex(@"[а-я]+");
            if (!hasLowerCase.IsMatch(password))
            {
                returningMessage.Item2 += "No lowercase in password\n";
            }
            var hasSpecSymbol = new Regex(@"\W{1}");
            if (!hasSpecSymbol.IsMatch(password))
            {
                returningMessage.Item2 += "No special symbols in password\n";
            }
            isValidatedPassword = noEng.IsMatch(password)
                && password.Count() >= minPasswordLength
                && hasNumber.IsMatch(password)
                && hasUpperCase.IsMatch(password)
                && hasLowerCase.IsMatch(password)
                && hasSpecSymbol.IsMatch(password);

            if(password != verifyPassword)
            {
                returningMessage.Item2 += "Passwords not matched";
            }


            if(isValidatedPassword && isValidatedLogin && password == verifyPassword)
            {
                returningMessage.Item1 = true;
            }
            else
            {
                returningMessage.Item1 = false;
            }


            return returningMessage;
        }
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
