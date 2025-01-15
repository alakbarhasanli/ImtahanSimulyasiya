using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.DAL.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Project.DAL.Contexts
{
    public class ThirdProjectDbContext:IdentityDbContext<AppUser>
    {
        public DbSet<News> news { get; set; }
        public DbSet<Category> categories { get; set; }
        public ThirdProjectDbContext(DbContextOptions opt):base(opt)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            

        }
       
    }
}
