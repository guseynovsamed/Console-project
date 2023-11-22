using Domain.Models;
using Respository.Data;
using Respository.Repositories;
using Respository.Repositories.Interfaces;
using Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepo;
        public GroupService()
        {
            _groupRepo = new GroupRepository();
        }

        public void Create(Group group)
        {
            _groupRepo.Create(group);
        }

        public void Delete(Group group)
        {
            _groupRepo.Delete(group);
        }

        public void Edit(Group group)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetAll()
        {
            return _groupRepo.GetAll();
        }

        public Group GetById(int id)
        {
            return _groupRepo.GetById(id);
        }

        public List<Group> Search(string searchText)
        {
            return _groupRepo.Search(searchText);
        }

        public List<Group> Sort()
        {
            return _groupRepo.Sort();
        }
    }
}
