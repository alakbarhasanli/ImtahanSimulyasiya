using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using Project.DAL.Contexts;
using Project.DAL.Helpers;
using Project.DAL.Repositories.Abstractions;
using Project.DAL.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Extentions
{
    public static class AddingServicesForDAL
    {
        public static void AddServicesForDal (this IServiceCollection service)
        {
            
            service.AddDbContext<SecondProjectDbContext>(opt => opt.UseSqlServer(GetConnectionStr.GetConnnection()));
            
            service.AddScoped<ITechnicianReadRepository, TechnicianReadRepository>();
            service.AddScoped<ITechnicianWriteRepository, TechnicianWriteRepository>();
            service.AddScoped<IServiceWriteRepository, ServiceWriteRepository>();
            service.AddScoped<IServiceReadRepository, ServiceReadRepository>();

        }
    }
}
