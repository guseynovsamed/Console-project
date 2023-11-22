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
        void Edit(Student student);
        void Delete(Student student);
        Student GetById(int id);
        List<Student> GetAll();
        List<Student> Search(string searchText);
        List<Student> Filter();
    }
}
