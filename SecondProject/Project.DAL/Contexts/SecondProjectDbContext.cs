using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Contexts
{
    public class SecondProjectDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Service> services { get; set; }
        public DbSet<Technicians> technicians { get; set; }

        public SecondProjectDbContext(DbContextOptions opt) : base(opt)
        {

        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
       

    }
}
