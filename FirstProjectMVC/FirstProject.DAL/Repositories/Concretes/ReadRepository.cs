using FirstProject.DAL.Contexts;
using FirstProject.DAL.Entitites;
using FirstProject.DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.DAL.Repositories.Concretes
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity, new()
    {
        private readonly FirstProjectDbContext _context;
        public ReadRepository(FirstProjectDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        

        public async Task<ICollection<T>> GetAllAsync()
        {
           return await Table.ToListAsync();
        }

        public async Task<T> GetOneByIDAsync(int id, bool IsTracking, params string[] includes)
        {
            IQueryable<T> query = Table.AsQueryable();
            if(!IsTracking)
            {
                query = query.AsNoTracking();
            }
            if(includes.Length>0)
            {
             foreach(var include in includes)
                {
                    query = query.Include(include);
                }
            }
           T? entity= await query.FirstOrDefaultAsync(e => e.Id == id);
            return entity;

        }
        public IQueryable<T> GetAllByCondition(System.Linq.Expressions.Expression<Func<T, bool>> condition)
        {
            IQueryable<T> query = Table.AsQueryable();
            query.Where(condition);
            return query;
        }

        public async Task<T> GetOneByCondition(System.Linq.Expressions.Expression<Func<T, bool>> condition)
        {
            IQueryable<T> query = Table.AsQueryable();
            T? entity = await query.SingleOrDefaultAsync(condition);
            return entity;
        }

    }
}
