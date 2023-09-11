using System;
using Serilog;
using System.Linq;


namespace laba
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var bd = new DBManager().db)
                {
                    string template = "{Timestamp:HH:mm:ss} | [{Level:u3}] | {Message:lj}{NewLine}{Exception}";
                    Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Debug()
                        .WriteTo.Console(outputTemplate: template)
                        .WriteTo.File("logs/file_.txt", outputTemplate: template)
                        .CreateLogger();
                    Log.Verbose("Logger configured");

                    bool loginBusy = true;
                    String login = "";
                    String password;
                    String passwordVerify;
                    Console.WriteLine("Registration");
                    while (loginBusy || !Validation.ValidateLogin(login))
                    {
                        Console.WriteLine("Input login");
                        login = Console.ReadLine();
                        loginBusy = bd.Users.Where(x => x.userLogin == login).Count() > 0;

                        if (loginBusy)
                        {
                            Log.Warning("Login is busy");
                        }
                    }
                    Log.Information("Login is correct");
                    do
                    {
                        do
                        {
                            Console.WriteLine("Input password");
                            password = Console.ReadLine();
                            if (!Validation.ValidatePassword(password))
                            {
                                Log.Warning("Password is not correct");
                            }
                        }
                        while (!Validation.ValidatePassword(password));
                        Log.Information("Password correct. Input once more.");
                        passwordVerify = Console.ReadLine();
                        if (passwordVerify != password)
                        {
                            Log.Warning("Password are different");
                        }
                    }
                    while (password != passwordVerify);


                    Users tmpUser = new Users() { userLogin = login, userPSW = password };
                    bd.Users.Add(tmpUser);
                    bd.SaveChanges();


                    Log.Information("Registration succesful");




                    Console.WriteLine("Login: " + login + "\nPassword: " + password + "\n");
                    foreach (Users users in bd.Users)
                    {
                        Console.WriteLine(users.userLogin);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }
            Console.ReadKey();
        }
    }
}
