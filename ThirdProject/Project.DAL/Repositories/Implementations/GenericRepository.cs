using Microsoft.EntityFrameworkCore;
using Project.DAL.Contexts;
using Project.DAL.Entitites;
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
        private readonly ThirdProjectDbContext _context;

        public GenericRepository(ThirdProjectDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await Table.ToListAsync();
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
            T? existingEntity = await query.FirstOrDefaultAsync(e => e.Id == id);
            if (existingEntity == null)
            {
                throw new Exception("Entity with this id not found");
            }
            return existingEntity;
        }
        public async Task CreateAsync(T entity)
        {
            await Table.AddAsync(entity);
        }
        public void UpdateAsync(T entity)
        {
            Table.Update(entity);
        }

        public void DeleteAsync(T entity)
        {
            Table.Remove(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            int rows = await _context.SaveChangesAsync();
            return rows;
        }
    }
}
