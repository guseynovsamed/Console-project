using Domain.Models;
using Respository.Data;
using Service.Helpers.Constants;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleProject.Controllers
{
    public class StudentController
    {
        private readonly IStudentService _studentService;
        private readonly IGroupService _groupService;
        public StudentController()
        {
            _studentService = new StudentService();
            _groupService = new GroupService();
        }
        public void Create()
        {
            var res = _groupService.GetAll();
            if (res.Count == 0)
            {
                ConsoleColor.Red.WriteConsole("Group not created , Please create a group");
                return;
            }
            Name: Console.WriteLine("Enter student name and surname :");
            string fullName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(fullName))
            {
                ConsoleColor.Red.WriteConsole(BaseNotification.InputEmptyMessage);
                goto Name;
            }

            Address: Console.WriteLine("Enter student address:");
            string address = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(address))
            {
                ConsoleColor.Red.WriteConsole(BaseNotification.InputEmptyMessage);
                goto Address;
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
            } else if (age > 100)
            {
                ConsoleColor.Red.WriteConsole("Registration age must be maximum 100");
                goto Age;
            }

            Phone: Console.WriteLine("Student phone number :");
            string phone = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(phone))
            {
                ConsoleColor.Red.WriteConsole(BaseNotification.InputEmptyMessage);
                goto Phone;
            }
            else if (phone.CheckPhone() is false)
            {
                ConsoleColor.Red.WriteConsole("Phone format is invalid.Please check number and try again");
                goto Phone;
            }

            Group: Console.WriteLine("Enter qroup Id ");
            string groupStr = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(groupStr))
            {
                ConsoleColor.Red.WriteConsole(BaseNotification.InputEmptyMessage);
                goto Group;
            }
            int id;
            bool IsCorrectiDFormat = int.TryParse(groupStr, out id);
            if (IsCorrectiDFormat is false)
            {
                ConsoleColor.Red.WriteConsole(BaseNotification.FormatWrong);
                goto Group;
            }
            var group = _groupService.GetById(id);
            if (group is null)
            {
                ConsoleColor.Red.WriteConsole("Group not found");
                goto Group;
            }
            Student student = new Student()
            {
                FullName = fullName,
                Address = address,
                Age = age,
                Phone = phone,
                Group = group,
            };

            _studentService.Create(student);
            ConsoleColor.Green.WriteConsole("Created success");
        }

        public void Delete()
        {
            var students = _studentService.GetAll();
            foreach (var item in students)
            {
                Console.WriteLine(item.Id + " " + item.FullName + " " + item.Age + " " + item.Address + " " + item.Phone);
            }

            Delete: Console.WriteLine("Enter Id for delete");
            string idStr = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(idStr))
            {
                ConsoleColor.Red.WriteConsole(BaseNotification.InputEmptyMessage);
                goto Delete;
            }
            int id;
            bool IsCorrectFormat = int.TryParse(idStr, out id);
            if (IsCorrectFormat is false)
            {
                ConsoleColor.Red.WriteConsole(BaseNotification.FormatWrong);
                goto Delete;
            }
            var student = students.FirstOrDefault(n => n.Id == id);
            if (student == null)
            {
                ConsoleColor.Red.WriteConsole("Group not found");
                goto Delete;
            }

            _studentService.Delete(student);
            ConsoleColor.Green.WriteConsole("Delete success");
        }
        public void Edit()
        {
            Edit: Console.WriteLine("Enter Id of the student to change");
            string idStr = Console.ReadLine();
            int id;
            bool isIdCorrectFormat = int.TryParse(idStr, out id);
            if (isIdCorrectFormat is false)
            {
                ConsoleColor.Red.WriteConsole(BaseNotification.FormatWrong);
                goto Edit;
            }
            Student student = _studentService.GetById(id);
            if (student is null)
            {
                ConsoleColor.Red.WriteConsole("Student not found");
                return;
            }

            Console.WriteLine("Enter student name :");
            string fullName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(fullName))
            {
                fullName = student.FullName;
            }

            Console.WriteLine("Enter student address");
            string address = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(address))
            {
                address = student.Address;
            }
            Age: Console.WriteLine("Enter student age");
            string ageStr = Console.ReadLine();
            byte age;
            if (string.IsNullOrWhiteSpace(ageStr))
            {
                age = student.Age;
                goto Phone;
            }
            bool IsAgeCorrectFormat = byte.TryParse(ageStr, out age);
            if (IsAgeCorrectFormat is false)
            {
                ConsoleColor.Red.WriteConsole(BaseNotification.FormatWrong);
                goto Age;
            }

            Phone: Console.WriteLine("Enter student phone");
            string phone = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(phone))
            {
                phone = student.Phone;
            }
            if(phone.CheckPhone()is false)
            {
                ConsoleColor.Red.WriteConsole(BaseNotification.FormatWrong);
                goto Phone;
            }

            var res = _groupService.GetAll();
            foreach (var item in res)
            {
                Console.WriteLine(item.Id+" "+item.Name+" "+item.Capacity);
            }

            GroupId: Console.WriteLine("Enter qroup id: ");
            string groupStr = Console.ReadLine();
            int groupId;
            if (string.IsNullOrWhiteSpace(groupStr))
            {
                groupId = student.Group.Id;
                goto EditEnd;
            }
            bool IsGroupIdCorrectFormat = int.TryParse(groupStr, out groupId);
            if (IsGroupIdCorrectFormat is false)
            {
                ConsoleColor.Red.WriteConsole(BaseNotification.FormatWrong);
                goto GroupId;
            }
            Group? group = _groupService.GetById(groupId);
            if (group is null)
            {
                ConsoleColor.Red.WriteConsole(BaseNotification.DataNotFound);
                return;
            }

            EditEnd: _studentService.Edit(id, fullName, address, age, phone, groupId);
            ConsoleColor.Green.WriteConsole("Edit success");
        }

    public void GetById()
        {
            Print: Console.WriteLine("Enter Id for print the Student");
            string idStr = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(idStr))
            {
                ConsoleColor.Red.WriteConsole(BaseNotification.InputEmptyMessage);
                goto Print;
            }
            int id;
            bool IsCorrectFormat = int.TryParse(idStr, out id);
            if (IsCorrectFormat is false)
            {
                ConsoleColor.Red.WriteConsole(BaseNotification.FormatWrong);
                goto Print;
            }
            var result = _studentService.GetById(id);
            if(result is null)
            {
                ConsoleColor.Red.WriteConsole("Student  not found");
                goto Print;
            }
            Console.WriteLine(result.Id+ "-" + result.FullName+ " " + result.Age + " " + result.Address + " " + result.Phone + " " + result.Group);
        }

        public void GetAll()
        {
            Console.WriteLine("Student information");
            var res = _studentService.GetAll();
            foreach (var item in res)
            {
                Console.WriteLine(item.Id + " " + item.FullName + " " + item.Age + " " + item.Address + " " + item.Phone + " " + item.Group.Name);
            }
        }
        public void Search()
        {
            Print: Console.WriteLine("Please enter student fullname");
            string text = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(text))
            {
                ConsoleColor.Red.WriteConsole(BaseNotification.InputEmptyMessage);
                goto Print;
            }
            var result = _studentService.Search(text.ToLower().Trim());
            if (result.Count()==0)
            {
                ConsoleColor.Red.WriteConsole(BaseNotification.DataNotFound);
                goto Print;
            }

            foreach (var item in result)
            {
                Console.WriteLine(item.Id + " " + item.FullName + " " + item.Age + " " + item.Address + " " + item.Phone + " " + item.Group.Name);
            }
        }

        public void Filter()
        {
            Searchtext: Console.WriteLine("Enter search text:(asc/desc)");
            string searchText = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                ConsoleColor.Red.WriteConsole(BaseNotification.InputEmptyMessage);
                goto Searchtext;
            }
            if (searchText != "asc" && searchText != "desc")
            {
                ConsoleColor.Red.WriteConsole("Text in wrong please check and enter again");
                goto Searchtext;
            }
            var res = _studentService.Filter(searchText);
            foreach (var item in res)
            {
                Console.WriteLine(item.Id + " " + item.FullName + " " + item.Age + " " + item.Address + " " + item.Phone + " " + item.Group.Name);
            }
        }
    }
}
