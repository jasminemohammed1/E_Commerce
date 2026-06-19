using E_commerce.Infrastructure.Data;
using E_commerce.Infrastructure.DataSeading;
using E_Commerce.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices( this IServiceCollection service  ,IConfiguration configuration)
        {
            service.AddDbContext<StoreDbContext>( opts => 
            opts.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            service.AddKeyedScoped<IDataSeader, CatalogDataSeader>("catalog");



            return service;

        }
    }
}
