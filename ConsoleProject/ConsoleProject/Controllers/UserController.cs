using Domain.Models;
using Service.Helpers.Constants;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interface;

namespace ConsoleProject.Controllers
{
    public class UserController
    {
        private readonly IUserService _userService;
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
                ConsoleColor.Red.WriteConsole(BaseNotification.InputEmptyMessage);
                goto Name;
            }

            Surname: Console.WriteLine("Surname :");
            string surname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(surname))
            {
                ConsoleColor.Red.WriteConsole(BaseNotification.InputEmptyMessage);
                goto Surname;
            }

            Age: Console.WriteLine("Enter student age");
            string ageStr = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(ageStr))
            {
                ConsoleColor.Red.WriteConsole(BaseNotification.InputEmptyMessage);
                goto Age;
            }
            byte age;
            bool IsCorrectFormat = byte.TryParse(ageStr, out age);
            if (IsCorrectFormat is false)
            {
                ConsoleColor.Red.WriteConsole(BaseNotification.FormatWrong);
                goto Age;
            }
            if (age <= 18)
            {
                ConsoleColor.Red.WriteConsole("Registration age must be min 18");
                goto Age;
            }
            else if (age > 100)
            {
                ConsoleColor.Red.WriteConsole("Registration age must be maximum 100");
                goto Age;
            }

            Email: Console.WriteLine("Email :");
            string email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email))
            {
                ConsoleColor.Red.WriteConsole(BaseNotification.InputEmptyMessage);
                goto Email;
            } 
            else if (email.EmailCheck() is false)
            {
                ConsoleColor.Red.WriteConsole(BaseNotification.FormatWrong);
                goto Email;
            }

            Password: Console.WriteLine("Password :");
            string password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(password))
            {
                ConsoleColor.Red.WriteConsole(BaseNotification.InputEmptyMessage);
                goto Password;
            }

            Console.WriteLine("Confirm password :");
            string confPassword =Console.ReadLine();
            if (string.IsNullOrWhiteSpace(confPassword))
            {
                ConsoleColor.Red.WriteConsole(BaseNotification.InputEmptyMessage);
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
        public bool Login()
        {
            Email: Console.WriteLine("Enter Email");
            string email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email))
            {
                ConsoleColor.Red.WriteConsole(BaseNotification.InputEmptyMessage);
                goto Email;
            }
            else if (email.EmailCheck() is false)
            {
                ConsoleColor.Red.WriteConsole("Email format is wrong");
                goto Email;
            }
            

            Console.WriteLine("Enter Password");
            string password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(password))
            {
                ConsoleColor.Red.WriteConsole(BaseNotification.InputEmptyMessage);
                goto Email;
            }

            if (_userService.Login(email,password))
            {
                ConsoleColor.Green.WriteConsole("Login Successfull");
                return true;
            }

            ConsoleColor.Red.WriteConsole("Email or password is wrong!");
            return false;
        }

    }
}
