using Domain.Models;
using Respository.Data;

namespace Respository.Repositories.Interfaces
{
    public  interface IGroupRepository : IBaseRepository<Group>
    {
        public List<Group> Search(string searchText);
        public List<Group> Sort();
        
    }
}
