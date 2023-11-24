using Domain.Models;
using Respository.Data;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Controllers
{
    public class StudentController
    {
        private readonly StudentService _studentService;
        public StudentController()
        {
            _studentService = new StudentService();
        }
        public void Create()
        {
            Name: Console.WriteLine("Enter student name and surname :");
            string fullName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(fullName))
            {
                ConsoleColor.Red.WriteConsole("Can not be empity");
                goto Name;
            }

            Address: Console.WriteLine("Enter student address:");
            string address = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(address))
            {
                ConsoleColor.Red.WriteConsole("Can not be empity");
                goto Address;
            }

            Age: Console.WriteLine("Enter student age");
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

            Phone: Console.WriteLine("Student phone number :");
            string phone = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(phone))
            {
                ConsoleColor.Red.WriteConsole("Can not be empity");
                goto Phone;
            }else if (phone.CheckPhone())
            {
                Console.WriteLine("duz");
                phone.CheckPhone();
            }
            else
            {
                Console.WriteLine("Phone format is invalid.Please check number and try again");
                goto Phone;
            }

            Id: Console.WriteLine("Enter the group Id of the student you want to add");
            string groupStr = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(groupStr))
            {
                ConsoleColor.Red.WriteConsole("Can not be empity");
                goto Id;
            }
            int group;
            bool IsCorrectFormate = int.TryParse(groupStr, out group);
            if (IsCorrectFormat is false)
            {
                ConsoleColor.Red.WriteConsole("Format is wrong");
                goto Id;
            }

















            Student student = new Student()
            {
                FullName = fullName,
                Address = address,
                Age = age,
                Phone = phone,
                Group = 
            };

            _studentService.Create(student);
        }

        public void Delete()
        {
            var groups = _studentService.GetAll();
            foreach (var item in groups)
            {
                Console.WriteLine(item.Id + " " + item.FullName + " " + item.Age+" "+item.Address+" "+item.Phone+" "+item.Group);
            }

            Delete: Console.WriteLine("Enter Id for delete");
            string idStr = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(idStr))
            {
                ConsoleColor.Red.WriteConsole("Can not be empity");
                goto Delete;
            }
            int id;
            bool IsCorrectFormat = int.TryParse(idStr, out id);
            if (IsCorrectFormat is false)
            {
                ConsoleColor.Red.WriteConsole("Format is wrong");
                goto Delete;
            }
            var group = groups.FirstOrDefault(n => n.Id == id);

            _studentService.Delete(group);
        }
        public void Edit()
        {

        }

        public void GetById()
        {
            Print: Console.WriteLine("Enter Id for print the Student");
            string idStr = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(idStr))
            {
                ConsoleColor.Red.WriteConsole("Can not be empity");
                goto Print;
            }
            int id;
            bool IsCorrectFormat = int.TryParse(idStr, out id);
            if (IsCorrectFormat is false)
            {
                ConsoleColor.Red.WriteConsole("Format is wrong");
                goto Print;
            }
            var result = _studentService.GetById(id);
            Console.WriteLine(result.Id+ "-" + result.FullName+ " " + result.Age + " " + result.Address + " " + result.Phone + " " + result.Group);
        }

        public void GetAll()
        {
            Console.WriteLine("Student information");
            var res = _studentService.GetAll();
            foreach (var item in res)
            {
                Console.WriteLine(item.Id + " " + item.FullName + " " + item.Age + " " + item.Address + " " + item.Phone + " " + item.Group);
            }
        }
        public void Search()
        {
            Print: Console.WriteLine("Please enter student fullname");
            string text = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(text))
            {
                ConsoleColor.Red.WriteConsole("Can not be empity");
                goto Print;
            }
            var result = _studentService.Search(text);

            foreach (var item in result)
            {
                Console.WriteLine(item.Id + " " + item.FullName + " " + item.Age + " " + item.Address + " " + item.Phone + " " + item.Group);
            }
        }

        public void Sorting()
        {
            Text: Console.WriteLine("Enter search text:(asc/desc)");
            string searchText = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                ConsoleColor.Red.WriteConsole("Can not be empity");
                goto Text;
            }
            var res = _studentService.Filter();
            foreach (var item in res)
            {
                Console.WriteLine(item.Id + " " + item.FullName + " " + item.Age + " " + item.Address + " " + item.Phone + " " + item.Group);
            }
        }



    }
}
