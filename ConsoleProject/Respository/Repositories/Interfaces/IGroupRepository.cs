using Domain.Models;
using Respository.Data;

namespace Respository.Repositories.Interfaces
{
    public  interface IGroupRepository : IBaseRepository<Group>
    {
        List<Group> Search(string searchText);
        List<Group> Sorting(string text);
        
    }
}
