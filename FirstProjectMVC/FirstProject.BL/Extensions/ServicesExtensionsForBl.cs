using FirstProject.BL.Profiles;
using FirstProject.BL.Services.Abstractions;
using FirstProject.BL.Services.Concretes;
using FirstProject.BL.Validations;
using FirstProject.DAL.Contexts;
using FirstProject.DAL.Repositories.Abstractions;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.BL.Extensions
{
    public static class ServicesExtensionsForBl
    {
        public static void AddingServicesForBL(this IServiceCollection services)
        {
            services.AddScoped<ICardItemService, CardItemService>();



            services.AddAutoMapper(typeof(CardItemProfile).Assembly);



            services.AddValidatorsFromAssembly(typeof(CardItemValidation).Assembly);
            services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
        }
    }
}
