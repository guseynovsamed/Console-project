using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interface
{
    public interface IStudentService
    {
        void Create(Student student);
        Student Edit(int id, string fullName, string address, byte age, string phone, int groupId);
        void Delete(Student student);
        Student GetById(int id);
        List<Student> GetAll();
        List<Student> Search(string searchText);
        List<Student> Filter(string text);
    }
}
