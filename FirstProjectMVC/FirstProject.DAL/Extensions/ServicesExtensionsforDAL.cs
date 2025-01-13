using FirstProject.DAL.Contexts;
using FirstProject.DAL.Helpers;
using FirstProject.DAL.Repositories.Abstractions;
using FirstProject.DAL.Repositories.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.DAL.Extensions
{
    public static class ServicesExtensionsforDAL
    {
        public static void AddingServicesForDal(this IServiceCollection services)
        {
            services.AddDbContext<FirstProjectDbContext>(opt => opt.UseSqlServer(GetConnectionStr.GetConnection()));

            services.AddScoped<ICardItemReadRepository, CardItemReadRepository>();
            services.AddScoped<ICardItemWriteRepository, CardItemWriteRepository>();
        }

        
    }
}
