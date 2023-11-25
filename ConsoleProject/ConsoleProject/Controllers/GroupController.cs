using Domain.Models;
using Respository.Data;
using Service.Helpers.Extensions;
using Service.Services;

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
            } else if (name.RepetitionName())
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
            bool IsCorrectFormat = int.TryParse(idStr , out id );
            if (IsCorrectFormat is false)
            {
                ConsoleColor.Red.WriteConsole("Format is wrong");
                goto Delete;
            }
            Group? group = _groupService.GetById(id);

            _groupService.Delete(group);
        }
        public void Edit()
        {
            Edit: Console.WriteLine("Enter Id for edit the group");
            GetAll();
            string idStr = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(idStr))
            {
                ConsoleColor.Red.WriteConsole("Can not be empty");
                goto Edit;
            }
            int id;
            bool IsCorrectFormat = int.TryParse(idStr, out id);
            if (IsCorrectFormat is false)
            {
                ConsoleColor.Red.WriteConsole("Format is wrong");
                goto Edit;
            }
            Group? group = _groupService.GetById(id);

            if (group is null)
            {
                ConsoleColor.Red.WriteConsole("Group not found");
                goto Edit;
            }

            Editname: Console.WriteLine("Enter for group new name :");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                goto Capacity;
            }
            foreach (var item in _groupService.GetAll())
            {
                if(item.Name == name)
                {
                    ConsoleColor.Red.WriteConsole("Duplicate name exists on the network");
                    goto Editname;
                }
            }
            group.Name = name;

            Capacity: Console.WriteLine("Enter for group new capacity");
            string capacityStr = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(capacityStr))
            {
                goto EditCompleted;
            }
            int capacity;
            bool isCapacityCorrectFormat = int.TryParse(capacityStr, out capacity);
            if (isCapacityCorrectFormat is false)
            {
                ConsoleColor.Red.WriteConsole("Format is wrong");
                goto Capacity;
            }else if (capacity <= 0)
            {
                ConsoleColor.Red.WriteConsole("Capacity cannot be negative");
                goto Capacity;
            }
            group.Capacity= capacity;

            EditCompleted: ConsoleColor.Green.WriteConsole("Group updated successfully");

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
            }else if (id <= 0)
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

            Console.WriteLine(group.Id+"-"+ group.Name+" "+ group.Capacity);
        }

        public void GetAll()
        {
            Console.WriteLine("Group information");
            var res = _groupService.GetAll();
            foreach(var item in res)
            {
                Console.WriteLine(item.Id+"-"+item.Name+"-"+item.Capacity);
            }
        }

        public void Search()
        {
            Print: Console.WriteLine("Please enter search text");
            string text = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(text))
            {
                ConsoleColor.Red.WriteConsole("Can not be empity");
                goto Print;
            }
            var result = _groupService.Search(text);

            foreach (var item in result)
            {
                Console.WriteLine(item.Id+"-"+item.Name+" "+item.Capacity);
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
            if (searchText != "asc"  && searchText != "desc")
            {
                ConsoleColor.Red.WriteConsole("Text in wrong please check and enter again");
                goto Searchtext;
            }
            var res =_groupService.Sorting(searchText);
            foreach (var item in res)
            {
                Console.WriteLine(item.Id + "-" + item.Name + " " + item.Capacity);
            }
        }
    }
}
