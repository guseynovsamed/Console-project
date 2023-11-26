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
    public class StudentService : IStudentService
    {
        private readonly IStudentRespository _studentRepo;
        public StudentService()
        {
            _studentRepo = new StudentRepository();
        }
        public void Create(Student student)
        {
            _studentRepo.Create(student);
        }

        public void Delete(Student student)
        {
            _studentRepo.Delete(student);
        }

        public Student Edit(int id, string fullName, string address, byte age, string phone, int groupId)
        {
            return _studentRepo.Edit(id, fullName, address, age, phone, groupId);
        }

        public List<Student> Filter(string text)
        {
            return _studentRepo.Filter(text);
        }

        public List<Student> GetAll()
        {
            return _studentRepo.GetAll();
        }

        public Student GetById(int id)
        {
            return _studentRepo.GetById(id);
        }

        public List<Student> Search(string searchText)
        {
            return _studentRepo.Search(searchText);
        }
    }
}
