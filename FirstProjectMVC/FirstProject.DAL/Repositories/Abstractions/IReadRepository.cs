using FirstProject.DAL.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.DAL.Repositories.Abstractions
{
    public interface IReadRepository<T>:IGenericRepository<T> where T:BaseEntity,new()
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T> GetOneByIDAsync(int id, bool IsTracking, params string[] includes);
        Task<T> GetOneByCondition(Expression<Func<T, bool>> condition);
        IQueryable<T> GetAllByCondition(Expression<Func<T, bool>> condition);
    }
}
