using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Abstractions
{
    public  interface IReadRepository<T>:IGenericRepository<T> where T:BaseEntity,new ()
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T> GetOneByIdAsync(int id, bool IsTracking, params string[] includes);
    }
}
