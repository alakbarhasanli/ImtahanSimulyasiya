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

        public async Task<T> GetOneByIdAsync(int id)
        {
            var existingEntity = await Table.FirstOrDefaultAsync(x => x.Id == id);
            if (existingEntity == null)
            {
                throw new Exception("Data not found");
            }
            _context.Entry(existingEntity).State = EntityState.Detached;
            return existingEntity;
        }

        public async Task<int> SaveChangesAsync()
        {
             return await _context.SaveChangesAsync();
            
        }

        public void Update(T Entity)
        {
            _context.Entry(Entity).State = EntityState.Modified;
            
        }
    }
}
