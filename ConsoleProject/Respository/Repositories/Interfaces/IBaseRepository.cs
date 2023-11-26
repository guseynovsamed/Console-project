﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respository.Repositories.Interfaces
{
    public interface IBaseRepository <T> where T : BaseEntity
    {
        void Create(T entity);
        void Delete (T entity);
        T? GetById (int id);
        List<T> GetAll();
    }
}
