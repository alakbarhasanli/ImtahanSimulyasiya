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
    public class FourthDbContext:IdentityDbContext<AppUser>
    {
        public DbSet<Doctors> doctors { get; set; }
        public DbSet<Department> departments { get; set; }

        public FourthDbContext(DbContextOptions opt):base(opt)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
