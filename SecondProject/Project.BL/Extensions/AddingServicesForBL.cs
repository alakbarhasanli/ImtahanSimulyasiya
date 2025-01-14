using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Project.BL.Profiles;
using Project.BL.Services.Abstractions;
using Project.BL.Services.Implementations;
using Project.BL.Validations;
using Project.DAL.Contexts;
using Project.DAL.Repositories.Abstractions;
using Project.DAL.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Extensions
{
    public static class AddingServicesForBL
    {
        public static void AddServicesForBL(this IServiceCollection service)
        {
            
            service.AddScoped<ITecniciansService, TechnicianService>();
            service.AddScoped<IService, Service>();

            service.AddAutoMapper(typeof(TechnicianProfile).Assembly);
            service.AddAutoMapper(typeof(ServiceProfile).Assembly);

            service.AddValidatorsFromAssembly(typeof(TechniciansValidation).Assembly);
            service.AddValidatorsFromAssembly(typeof(ServiceValidation).Assembly);

        }
    }
}
