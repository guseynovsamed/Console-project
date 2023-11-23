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
        public List<Group> Search(string searchText)
        {
            return AppDbContext<Group>.Datas.Where(n => n.Name.Contains(searchText)).ToList();
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
