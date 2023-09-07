using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba
{
    public static class Validation
    {
        private static int minLoginLength = 5;
        public static bool ValidateLogin(String login)
        {
            if(login.Count() > minLoginLength)
            {
                if (login.StartsWith("+") && login.Count() == 15)
                {
                    if (login[2].Equals('-') && login[6].Equals('-') && login[10].Equals('-'))
                    {
                        foreach(char c in login)
                        {
                            if(!char.IsDigit(c))
                            {
                                if(c != '+')
                                {
                                    if(c != '-')
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
                else if(login.Contains('@') && login.Contains('.'))
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
                    foreach (char c in login)
                    {
                        if(!char.IsLetterOrDigit(c))
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            return false;
        }
        public static bool ValidatePassword(String password)
        {
            return false;
        }
    }
}
