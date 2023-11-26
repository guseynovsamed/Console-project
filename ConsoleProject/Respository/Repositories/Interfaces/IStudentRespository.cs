using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respository.Repositories.Interfaces
{
    public interface IStudentRespository : IBaseRepository<Student>
    {
        List<Student> Search(string searchText);
        List<Student> Filter(string text);
        Student Edit( int id , string fullName, string address, byte age , string phone , int groupId);
    }
}
