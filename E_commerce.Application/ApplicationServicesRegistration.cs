using E_commerce.Application.Contracts;
using E_commerce.Application.Profiles;
using E_commerce.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application
{
    public static class ApplicationServicesRegistration
    {
       public static IServiceCollection AddApplicationService(this IServiceCollection services )
        {
            services.AddAutoMapper(c => { }, typeof(ApplicationServicesRegistration).Assembly);
            services.AddScoped<IProductService, ProductService>();
            
            return services;
        }
    }
}
