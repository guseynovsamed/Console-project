using Domain.Models;
using Respository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respository.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        bool Login(string email, string password);
        void Register(User user);
        
    }
}
