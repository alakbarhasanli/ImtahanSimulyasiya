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
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity, new()
    {
        private readonly FirstProjectDbContext _context;
        public WriteRepository(FirstProjectDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task CreateAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async void Update(T entity)
        {
             Table.Update(entity);
        }
        public void SoftDelete(T entity)
        {
            entity.IsDeleted = true;
            _context.Entry(entity).State = EntityState.Modified;
        }
        public void HardDelete(T entity)
        {
           if(!entity.IsDeleted)
            {
            throw new Exception("Entity Not Found");
            }
                Table.Remove(entity);
        }


        public async Task<int> SaveChangesAsync()
        {
            int rows = await _context.SaveChangesAsync();
            return rows;

        }

    }
}
