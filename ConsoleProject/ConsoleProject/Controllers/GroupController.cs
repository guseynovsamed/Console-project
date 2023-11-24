using Domain.Models;
using Respository.Data;
using Service.Helpers.Extensions;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                ConsoleColor.Red.WriteConsole("Can not be empity");
                goto Name;
            } else if (name.RepetitionName())
            {
                ConsoleColor.Red.WriteConsole("Duplicate name exists on the network");
                goto Name;
            }
            else
            {
                name.RepetitionName();
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

            Delete: Console.WriteLine("Enter Id for delete");
            string idStr = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(idStr))
            {
                ConsoleColor.Red.WriteConsole("Can not be empity");
                goto Delete;
            }
            int id;
            bool IsCorrectFormat = int.TryParse(idStr , out id );
            if (IsCorrectFormat is false)
            {
                ConsoleColor.Red.WriteConsole("Format is wrong");
                goto Delete;
            }
            var group = groups.FirstOrDefault(n=>n.Id == id);

            _groupService.Delete(group);
        }
        public void Edit()
        {

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
            var result = _groupService.GetById(id);
            Console.WriteLine(result.Id+"-"+result.Name+" "+result.Capacity);
        }

        public void GetAll()
        {
            Console.WriteLine("Group information");
            var res = _groupService.GetAll();
            foreach(var item in res)
            {
                Console.WriteLine(item.Id+"-"+item.Name+""+item.Capacity);
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
            Text: Console.WriteLine("Enter search text:(asc/desc)");
            string searchText = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                ConsoleColor.Red.WriteConsole("Can not be empity");
                goto Text;
            }
            var res =_groupService.Sorting(searchText);
            foreach (var item in res)
            {
                Console.WriteLine(item.Id + "-" + item.Name + " " + item.Capacity);
            }
        }

    }
}
