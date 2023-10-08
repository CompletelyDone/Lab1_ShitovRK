using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
                    try
                    {
                        MailAddress m = new MailAddress(login);

                        isValidatedLogin = true;
                    }
                    catch (FormatException)
                    {
                        isValidatedLogin = false;
                        returningMessage.Item2 += "Email isn't correct\n";
                    }
                }
                else
                {
                    var newReg = new Regex(@"");
                    var latinica = new Regex(@"[A-z]");
                    var numbers = new Regex(@"[0-9]");
                    var chara = new Regex(@"[_]");
                    isValidatedLogin = latinica.IsMatch(login) || numbers.IsMatch(login) || chara.IsMatch(login);
                    if(isValidatedLogin)
                    {
                        returningMessage.Item1 = true;
                    }
                    else
                    {
                        returningMessage.Item1 = false;
                        returningMessage.Item2 += "Login not correct\n";
                    }
                }
            }
            else
            {
                returningMessage.Item2 += "Minimal login length is 5\n";
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
                returningMessage.Item2 += "Passwords not matched\n";
            }

            try
            {
                using(var db = new DBManager().db)
                {
                    if(db.Users.Where(x=>x.userLogin == login).Count() > 0)
                    {
                        isValidatedLogin = false;
                        returningMessage.Item2 += "Login is busy";
                    }

                    if (isValidatedPassword && isValidatedLogin && password == verifyPassword)
                    {
                        Users user = new Users() { userLogin = login, userPSW = password };
                        db.Users.Add(user);
                        db.SaveChanges();
                        returningMessage.Item1 = true;
                    }
                    else
                    {
                        returningMessage.Item1 = false;
                    }
                }
            }
            catch (Exception ex)
            {
                returningMessage.Item2 += "Ошибка подключения к БД: " + ex.Message + "\n";
                returningMessage.Item1 = false;
            }

            


            return returningMessage;
        }
    }
}
