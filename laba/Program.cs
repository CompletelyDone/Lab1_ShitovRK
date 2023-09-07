using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DBManager bd = new DBManager();
            String login;
            String password;
            String passwordVerify;
            Console.WriteLine("Registration");
            Console.WriteLine("Input login(+x-xxx-xxx-xxxx)");
            login = Console.ReadLine();
            if(Validation.ValidateLogin(login))
            {
                Console.WriteLine("Login good");
            }
            else
            {
                Console.WriteLine("Login bad");
            }
            
            Console.WriteLine("Input password");
            password = Console.ReadLine();
            if (Validation.ValidatePassword(password))
            {
                Console.WriteLine("Password good");
            }
            else
            {
                Console.WriteLine("Password bad");
            }
            Console.WriteLine("Input password");
            passwordVerify = Console.ReadLine();

            Console.WriteLine("Login: " + login + "\nPassword: " + password + "\n");
            foreach(Users users in bd.db.Users)
            {
                Console.WriteLine(users.userLogin);
            }
            Console.ReadKey();
        }
    }
}
