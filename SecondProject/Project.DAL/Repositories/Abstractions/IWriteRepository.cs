﻿using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Abstractions
{
    public interface IWriteRepository<T>:IGenericRepository<T> where T:BaseEntity,new()
    {
        Task CreateAsync(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<int> SaveChangesAsync();

    }
}
