using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Project.BL.Profiles;
using Project.BL.Services.Abstractions;
using Project.BL.Services.Implementations;
using Project.BL.Validations;
using Project.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Extensions
{
    public static class ServiceExtensionForBL
    {
        public static void AddingServiceForBL(this IServiceCollection service)
        {
            service.AddScoped<INewsService, NewsService>();
            service.AddScoped<ICategoryService, CategoryService>();

            service.AddAutoMapper(typeof(NewsProfile).Assembly);
            service.AddAutoMapper(typeof(CategoryProfile).Assembly);

            service.AddValidatorsFromAssembly(typeof(NewsValidation).Assembly);
            service.AddValidatorsFromAssembly(typeof(CategoryValidation).Assembly);
            service.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();


        }
    }
}
