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
    public class StudentRepository : BaseRespository<Student>, IStudentRespository
    {

        public List<Student> Filter(string text)
        {
            if (text == "desc")
            {
                return AppDbContext<Student>.Datas.OrderByDescending(n => n.Age).ToList();
            }
            return AppDbContext<Student>.Datas.OrderBy(n => n.Age).ToList();
        }

        public List<Student> Search(string searchText)
        {
            return AppDbContext<Student>.Datas.Where(n=>n.FullName==n.FullName).ToList();
        }
    }
}
