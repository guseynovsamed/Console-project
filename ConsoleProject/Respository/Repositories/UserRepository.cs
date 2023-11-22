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
    public class UserRepository : BaseRespository<User> , IUserRepository
    {
        public bool Login(string email, string password)
        {
            var datas = AppDbContext<User>.Datas.ToList();
            foreach (var data in datas)
            {
                if (data.Email == email && data.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
        public void Register(User user)
        {
            AppDbContext<User>.Datas.Add(user);
        }
    }
}
