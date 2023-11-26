using Domain.Models;
using Respository.Data;
using Service.Helpers.Extensions;
using Service.Services;
using System.ComponentModel.DataAnnotations;

namespace ConsoleProject.Controllers
{
    public class GroupController
    {
        private readonly GroupService _groupService;
        public GroupController()
        {
            _groupService = new GroupService();

        }
        public void Create()
        {
            Name: Console.WriteLine("Enter group name :");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteConsole("Can not be empty");
                goto Name;
            }
            else if (name.RepetitionName())
            {
                ConsoleColor.Red.WriteConsole("Duplicate name exists on the network");
                goto Name;
            }

            Capacity: Console.WriteLine("Enter group capacity");
            string capacityStr = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(capacityStr))
            {
                ConsoleColor.Red.WriteConsole("Can not be empity");
                goto Capacity;
            }
            int capacity;
            bool IsCorrectFormat = int.TryParse(capacityStr, out capacity);
            if (IsCorrectFormat is false)
            {
                ConsoleColor.Red.WriteConsole("Format is wrong");
                goto Capacity;
            }
            if (capacity <= 0)
            {
                ConsoleColor.Red.WriteConsole("Capacity cannot be negative");
                goto Capacity;
            }

            Group group = new Group()
            {
                Name = name,
                Capacity = capacity,
            };
            _groupService.Create(group);
            ConsoleColor.Green.WriteConsole("Group create success");
        }

        public void Delete()
        {
            var groups = _groupService.GetAll();
            foreach (var item in groups)
            {
                Console.WriteLine(item.Id + " " + item.Name + " " + item.Capacity);
            }

            Delete: ConsoleColor.Blue.WriteConsole("Enter Id for delete");
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
            Group? group = _groupService.GetById(id);
            if (group == null)
            {
                ConsoleColor.Red.WriteConsole("Data not found");
                goto Delete;
            }

            _groupService.Delete(group);
        }
        public void Edit()
        {
            EditLabel: Console.WriteLine("Enter Id for print the group");
            string idStr = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(idStr))
            {
                ConsoleColor.Red.WriteConsole("Can not be empty");
            }
            int id;
            bool isIdCorrectFormat = int.TryParse(idStr, out id);
            if (isIdCorrectFormat is false)
            {
                ConsoleColor.Red.WriteConsole("Format is wrong");
                goto EditLabel;
            }
            Group? group = _groupService.GetById(id);
            if (group is null)
            {
                ConsoleColor.Red.WriteConsole("Group not found");
                return;
            }

            Name: Console.WriteLine("Enter group name :");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                name = group.Name;
                goto Capacity;
            }
            if (_groupService.GetIsExistByName(name))
            {
                ConsoleColor.Red.WriteConsole("Duplicate name exists on the network");
                goto Name;
            }

            Capacity: Console.WriteLine("Enter group capacity");
            string capacityStr = Console.ReadLine();
            int capacity;
            if (string.IsNullOrWhiteSpace(capacityStr))
            {
                capacity = group.Capacity;
                goto EditEndLabel;
                ;
            }
            bool isCapacityCorrectFormat = int.TryParse(capacityStr, out capacity);
            if (isCapacityCorrectFormat is false)
            {
                ConsoleColor.Red.WriteConsole("Format is wrong");
                goto Capacity;
            }
            if (capacity < 0)
            {
                ConsoleColor.Red.WriteConsole("Capacity cannot be negative");
                goto Capacity;
            }

        EditEndLabel:
            ConsoleColor.Green.WriteConsole("Edit success");
            _groupService.Edit(id, name, capacity);
        }

        public void GetById()
        {
        Print: Console.WriteLine("Enter Id for print the group");
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
            else if (id <= 0)
            {
                ConsoleColor.Red.WriteConsole("Id cannot be negative");
                goto Print;
            }
            Group? group = _groupService.GetById(id);
            if (group is null)
            {
                ConsoleColor.Red.WriteConsole("Group not found");
                goto Print;
            }

            Console.WriteLine(group.Id + "-" + group.Name + " " + group.Capacity);
        }
        public void GetAll()
        {
            Console.WriteLine("Group information");
            var res = _groupService.GetAll();
            foreach (var item in res)
            {
                Console.WriteLine(item.Id + "-" + item.Name + "-" + item.Capacity);
            }
        }
        public void Search()
        {
            Print: Console.WriteLine("Please enter search text");
            string text = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(text))
            {
                ConsoleColor.Red.WriteConsole("Can not be empty");
                goto Print;
            }
            var result = _groupService.Search(text);
            if(text is null)
            {
                ConsoleColor.Red.WriteConsole("Data not found");
                goto Print;
            }

            foreach (var item in result)
            {
                Console.WriteLine(item.Id + "-" + item.Name + " " + item.Capacity);
            }
        }

        public void Sorting()
        {
            Searchtext: Console.WriteLine("Enter search text:(asc/desc)");
            string searchText = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                ConsoleColor.Red.WriteConsole("Can not be empty");
                goto Searchtext;
            }
            if (searchText != "asc" && searchText != "desc")
            {
                ConsoleColor.Red.WriteConsole("Text in wrong please check and enter again");
                return;
            }
            var res = _groupService.Sorting(searchText);
            foreach (var item in res)
            {
                Console.WriteLine(item.Id + "-" + item.Name + " " + item.Capacity);
            }
        }
    }
}
