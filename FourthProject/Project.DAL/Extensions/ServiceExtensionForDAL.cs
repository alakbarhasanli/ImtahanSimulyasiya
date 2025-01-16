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
    public static class ServiceExtensionForDAL
    {
        public static void AddingServicesForDAL(this IServiceCollection service)
        {
            service.AddDbContext<FourthDbContext>(opt => opt.UseSqlServer(GetConnectionStr.GetConnection()));
            service.AddScoped<IDepartmentRepository, DepartmentRepository>();
            service.AddScoped<IDoctorRepository, DoctorRepository>();
        }
    }
}
