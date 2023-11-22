﻿using Domain.Models;
using Respository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respository.Repositories
{
    public class StudentRepository : BaseRespository<Student> , IStudentRespository
    {
    }
}
