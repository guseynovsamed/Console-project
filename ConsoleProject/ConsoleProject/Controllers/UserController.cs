using Domain.Models;
using Service.Helpers.Extensions;
using Service.Services;

namespace ConsoleProject.Controllers
{
    public class UserController
    {
        private readonly UserService _userService;
        public UserController()
        {
            _userService = new UserService();
        }

        public void Register()
        {
            Name: Console.WriteLine("Name :");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteConsole("Can not be empity");
                goto Name;
            }

            Surname: Console.WriteLine("Surname :");
            string surname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(surname))
            {
                ConsoleColor.Red.WriteConsole("Can not be empity");
                goto Surname;
            }

            Age: Console.WriteLine("Age :");
            string ageStr = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(ageStr))
            {
                ConsoleColor.Red.WriteConsole("Can not be empity");
                goto Age;
            }
            byte age;
            bool IsCorrectFormat = byte.TryParse(ageStr, out age);
            if (IsCorrectFormat is false)
            {
                ConsoleColor.Red.WriteConsole("Format is wrong");
                goto Age;
            }
           

            Email: Console.WriteLine("Email :");
            string email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email))
            {
                ConsoleColor.Red.WriteConsole("Can not be empity");
                goto Email;
            } 
            else if (email.EmailCheck() is false)
            {
                ConsoleColor.Red.WriteConsole("Format is wrong");
                goto Email;
            }
          

            Password: Console.WriteLine("Password :");
            string password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(password))
            {
                ConsoleColor.Red.WriteConsole("Can not be empity");
                goto Password;
            }

            Console.WriteLine("Confirm password :");
            string confPassword =Console.ReadLine();
            if (string.IsNullOrWhiteSpace(confPassword))
            {
                ConsoleColor.Red.WriteConsole("Can not be empity");
                goto Password;
            }
            else if (password.ConfirmPasswordCheck(confPassword) is false)
            {
                goto Password;
            }

            User user = new User()
            {
                Name = name,
                Surname = surname,
                Age = age,
                Email = email,
                Password = password,
            };

            _userService.Register(user);
            ConsoleColor.Green.WriteConsole("Registry Complete");
        }
        public void Login()
        {
            Email: Console.WriteLine("Enter Email");
            string email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email))
            {
                ConsoleColor.Red.WriteConsole("Can not be empity");
            }else if (email.EmailCheck() is false)
            {
                goto Email;
            }
            

            Console.WriteLine("Enter Password");
            string password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(password))
            {
                ConsoleColor.Red.WriteConsole("Can not be empity");
            }

            if (_userService.Login(email,password))
            {
                ConsoleColor.Green.WriteConsole("Login Successfull");
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Incorrect username or password");
                goto Email;
            }
        }

    }
}
