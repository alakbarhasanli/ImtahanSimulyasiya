using FirstProject.DAL.Entitites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.DAL.Contexts
{
    public class FirstProjectDbContext:DbContext
    {
        public DbSet<CardItem> cardItems { get; set; }
        public FirstProjectDbContext(DbContextOptions opt):base(opt)
        {
            
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entities = ChangeTracker.Entries<AuditableEntity>();
            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Entity.CreatedAt = DateTime.Now;
                }
                if (entity.State == EntityState.Modified)
                {
                    entity.Entity.UpdatedAt = DateTime.Now;

                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
