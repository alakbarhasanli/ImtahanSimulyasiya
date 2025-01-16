using Microsoft.Extensions.DependencyInjection;
using Project.BL.Profiles;
using Project.BL.Services.Abstractions;
using Project.BL.Services.Implementations;
using Project.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Extensions
{
    public static class ServiceExtensionsForBL
    {
        public static void AddingServicesForBL(this IServiceCollection service)
        {
            service.AddScoped<IAuthService, AuthService>();
            service.AddScoped<IDepartmentService, DepartmentService>();
            service.AddScoped<IDoctorService, DoctorService>();

            service.AddAutoMapper(typeof(DepartmentProfile).Assembly);
            service.AddAutoMapper(typeof(AuthProfile).Assembly);
            service.AddAutoMapper(typeof(DoctorProfile).Assembly);
        }
    }
}
