using FirstProject.DAL.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.DAL.Repositories.Abstractions
{
    public interface IWriteRepository<T>:IGenericRepository<T> where T:BaseEntity,new ()
    {
        Task CreateAsync(T entity);
        void SoftDelete(T entity);
        void HardDelete(T entity);
        void Update(T entity);
        Task<int> SaveChangesAsync();


    }
}
