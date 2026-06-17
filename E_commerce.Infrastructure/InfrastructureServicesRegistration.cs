using E_commerce.Infrastructure.Data;
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



            return service;

        }
    }
}
