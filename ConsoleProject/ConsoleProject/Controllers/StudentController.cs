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
using System.Xml;

namespace ConsoleProject.Controllers
{
    public class StudentController
    {
        private readonly StudentService _studentService;
        private readonly GroupService _groupService;
        public StudentController()
        {
            _studentService = new StudentService();
            _groupService = new GroupService();
        }
        public void Create()
        {
            Name: Console.WriteLine("Enter student name and surname :");
            string fullName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(fullName))
            {
                ConsoleColor.Red.WriteConsole("Can not be empty");
                goto Name;
            }

            Address: Console.WriteLine("Enter student address:");
            string address = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(address))
            {
                ConsoleColor.Red.WriteConsole("Can not be empty");
                goto Address;
            }

            Age: Console.WriteLine("Enter student age");
            string ageStr = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(ageStr))
            {
                ConsoleColor.Red.WriteConsole("Can not be empty");
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
                ConsoleColor.Red.WriteConsole("Can not be empty");
                goto Phone;
            }
            else if (phone.CheckPhone() is false)
            {
                ConsoleColor.Red.WriteConsole("Phone format is invalid.Please check number and try again");
                goto Phone;
            }

            Group: Console.WriteLine("Enter qroup Id to change student group");
            string groupStr = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(groupStr))
            {
                ConsoleColor.Red.WriteConsole("Can not be empty");
                goto Group;
            }
            int id;
            bool IsCorrectiDFormat = int.TryParse(groupStr, out id);
            if (IsCorrectiDFormat is false)
            {
                ConsoleColor.Red.WriteConsole("Format is wrong");
                goto Group;
            }
            var group =_groupService.GetById(id);
            if (group is null)
            {
                Console.WriteLine("Group not found");
                goto Group;
            }
            Student student = new Student()
            {
                FullName = fullName,
                Address = address,
                Age = age,
                Phone = phone,
                Group= group,
            };

            _studentService.Create(student);
        }

        public void Delete()
        {
            var students = _studentService.GetAll();
            foreach (var item in students)
            {
                Console.WriteLine(item.Id + " " + item.FullName + " " + item.Age+" "+item.Address+" "+item.Phone+" "+item.Group);
            }

            Delete: Console.WriteLine("Enter Id for delete");
            string idStr = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(idStr))
            {
                ConsoleColor.Red.WriteConsole("Can not be empty");
                goto Delete;
            }
            int id;
            bool IsCorrectFormat = int.TryParse(idStr, out id);
            if (IsCorrectFormat is false)
            {
                ConsoleColor.Red.WriteConsole("Format is wrong");
                goto Delete;
            }
            var student = students.FirstOrDefault(n => n.Id == id);

            _studentService.Delete(student);
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
                ConsoleColor.Red.WriteConsole("Can not be empty");
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
                ConsoleColor.Red.WriteConsole("Can not be empty");
                goto Print;
            }
            var result = _studentService.Search(text);

            foreach (var item in result)
            {
                Console.WriteLine(item.Id + " " + item.FullName + " " + item.Age + " " + item.Address + " " + item.Phone + " " + item.Group);
            }
        }

        public void Filter()
        {
            Searchtext: Console.WriteLine("Enter search text:(asc/desc)");
            string searchText = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                ConsoleColor.Red.WriteConsole("Can not be empty");
                goto Searchtext;
            }
            if (searchText != "asc" || searchText != "desc")
            {
                ConsoleColor.Red.WriteConsole("Text in wrong please check and enter again");
                goto Searchtext;
            }
            var res = _studentService.Filter(searchText);
            foreach (var item in res)
            {
                Console.WriteLine(item.Id + " " + item.FullName + " " + item.Age + " " + item.Address + " " + item.Phone + " " + item.Group);
            }
        }
    }
}
