using Domain.Models;
using Respository.Data;
using Respository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respository.Repositories
{
    public class GroupRepository : BaseRespository<Group>, IGroupRepository
    {
        public Group Edit(int id, string newName, int newCapacity)
        {
            Group? group =  AppDbContext<Group>.Datas.FirstOrDefault((group) => group.Id == id);
            group.Name = newName;
            group.Capacity = newCapacity;

            return group;
        }

        public bool GetIsExistByName(string name)
        {
            return AppDbContext<Group>.Datas.Exists(group => group.Name == name);
        }

        public List<Group> Search(string searchText)
        {
            return AppDbContext<Group>.Datas.Where(n => n.Name.Trim().ToLower().Contains(searchText.ToLower().Trim())).ToList();
        }

        public List<Group> Sorting(string text)
        {
            if (text=="desc")
            {
                return AppDbContext<Group>.Datas.OrderByDescending(n => n.Capacity).ToList();
            }
            return AppDbContext<Group>.Datas.OrderBy(n => n.Capacity).ToList();
        }
    } 
}
