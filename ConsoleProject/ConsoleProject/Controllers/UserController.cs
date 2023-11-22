using Service.Helpers.Extensions;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Controllers
{
    public class UserController
    {
        private UserService _userService;
        public UserController()
        {
            _userService = new UserService();
        }

        public void Register()
        {
            Console.WriteLine("Name :");
            Name: string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteConsole("Can not be empity");
                goto Name;
            }

            Console.WriteLine("Surname :");
            Surname: string surname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(surname))
            {
                ConsoleColor.Red.WriteConsole("Can not be empity");
                goto Surname;
            }

            Console.WriteLine("Age :");
            Age: string ageStr = Console.ReadLine();
            byte age;
            bool IsCorrectFormat = byte.TryParse(ageStr, out age);
            if (IsCorrectFormat is false)
            {
                ConsoleColor.Red.WriteConsole("Format is wrong");
                goto Age;
            }
            if (string.IsNullOrWhiteSpace(ageStr))
            {
                ConsoleColor.Red.WriteConsole("Can not be empity");
            }

            Email: Console.WriteLine("Email :");
            string email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email))
            {
                ConsoleColor.Red.WriteConsole("Can not be empity");
                goto Email;
            } 
            else if (!UserExtension.EmailCheck(email))
            {
                goto Email;
            }
            

            

            Console.WriteLine("Password");
            Password: string password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(password))
            {
                ConsoleColor.Red.WriteConsole("Can not be empity");
                goto Password;
            }
           
            
            

            

            

           
    

    
            






        }
    }
}
