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
        public Student Edit(int id ,string fullName, string address, byte age, string phone, int groupId )
        {
            Student? student = AppDbContext<Student>.Datas.FirstOrDefault(n => n.Id == id);
            student.FullName = fullName;
            student.Address = address;
            student.Age = age;
            student.Phone = phone;
            student.Group = AppDbContext<Group>.Datas.FirstOrDefault(group=> group.Id == groupId);

            return student;
        }

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
            return AppDbContext<Student>.Datas.Where(n=>n.FullName.ToLower().Trim().Contains(searchText.ToLower().Trim())).ToList();
        }
    }
}
