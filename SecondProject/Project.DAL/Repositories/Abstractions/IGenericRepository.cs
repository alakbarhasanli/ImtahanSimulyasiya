using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Abstractions
{
    public interface IGenericRepository<T> where T:BaseEntity,new()
    {
        DbSet<T> Table { get; }
    }
}
