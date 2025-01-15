using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Project.DAL.Contexts;
using Project.DAL.Helpers;
using Project.DAL.Repositories.Abstractions;
using Project.DAL.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Extensions
{
    public static class ServiceExtensionForDal
    {
        public static void AddingServiceForDAL(this IServiceCollection service)
        {
            service.AddDbContext<ThirdProjectDbContext>(opt => opt.UseSqlServer(GetConnectionStr.GetConnection()));

            service.AddScoped<INewsRepository, NewsRepository>();
            service.AddScoped<ICategoryRepository, CategoryRepository>();
        }
    }
}
