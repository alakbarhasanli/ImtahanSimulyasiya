using Microsoft.EntityFrameworkCore;
using Project.DAL.Contexts;
using Project.DAL.Entities;
using Project.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Implementations
{
    public class ReadRepository<T>:IReadRepository<T> where T:BaseEntity,new()
    {
     private readonly SecondProjectDbContext _context;

    public ReadRepository(SecondProjectDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

        public async Task<ICollection<T>> GetAllAsync()
        {
            var allEntity = await Table.ToListAsync();
            return allEntity;
        }

        public async Task<T> GetOneByIdAsync(int id, bool IsTracking, params string[] includes)
        {
            IQueryable<T> query = Table.AsQueryable();
            if (!IsTracking)
            {
                query = query.AsNoTracking();
            }
            if (includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            T? entity = await query.FirstOrDefaultAsync(e => e.Id == id);
            return entity;
        }
    }
}
