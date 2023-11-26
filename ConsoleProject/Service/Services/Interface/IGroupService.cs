using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interface
{
    public  interface IGroupService
    {
        void Create(Group group);
        Group Edit(int id, string newName, int Capacity);
        void Delete(Group group);
        Group? GetById(int id);
        List<Group> GetAll();
        List<Group> Search(string searchText);
        List<Group> Sorting(string text);
    }
}
