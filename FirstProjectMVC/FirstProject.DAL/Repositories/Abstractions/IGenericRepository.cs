using FirstProject.DAL.Entitites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.DAL.Repositories.Abstractions
{
    public interface IGenericRepository<T> where T:BaseEntity,new()
    {
        DbSet<T> Table { get;  }
    }
}
