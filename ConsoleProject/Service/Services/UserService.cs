using Domain.Models;
using Respository.Repositories.Interfaces;
using Respository.Repositories;
using Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRep;
        public UserService()
        {
            _userRep = new UserRepository();
        }
        public bool Login(string email, string password)
        {
            return _userRep.Login(email, password);
        }

        public void Register(User user)
        {
            _userRep.Register(user);
        }
    }
}
