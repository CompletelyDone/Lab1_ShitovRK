using System;
using Serilog;
using System.Linq;


namespace laba
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string login;
            string password;
            string verifyPassword;
            (bool, string) isValidated;

            Console.WriteLine("Reg\nInput Login");
            login = Console.ReadLine();
            Console.WriteLine("Input password");
            password = Console.ReadLine();
            Console.WriteLine("Input password");
            verifyPassword = Console.ReadLine();
            isValidated = Validation.Validate(login, password, verifyPassword);

            Console.WriteLine("Is validated: " + isValidated.Item1 + "\nError Message:\n" + isValidated.Item2);
            Console.ReadKey();
        }
    }
}
