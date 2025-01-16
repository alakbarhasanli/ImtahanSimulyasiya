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
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        private readonly FourthDbContext _context;

        public GenericRepository(FourthDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task CreateAsync(T entity)
        {
           await Table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            Table.Remove(entity);
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await Table.ToListAsync();
        }

        public async Task<T> GetOneByIdAsync(int id, bool IsTracking, params string[] includes)
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
                var existingEntity = await query.FirstOrDefaultAsync(e => e.Id == id);
                if(existingEntity==null)
                {
                    throw new Exception("entity not Found with this id");
                }
                return existingEntity ;
        }

        public async Task<int> SaveChangesAsync()
        {
            int rows = await _context.SaveChangesAsync();
            return rows;
        }

        public void Update(T Entity)
        {
            Table.Update(Entity);
        }
    }
}
