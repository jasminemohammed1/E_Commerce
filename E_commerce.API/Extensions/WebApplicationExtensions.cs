using E_Commerce.Domain.Contracts;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace E_commerce.API.Extensions
{
    public static class WebApplicationExtensions
    {

      public static async Task<WebApplication> SeadAndMigrateAsync(this WebApplication app)
        {
          using var scope = app.Services.CreateScope();
           var service = scope.ServiceProvider.GetRequiredKeyedService<IDataSeader>("catalog");
           await service.DataSeadAsync();
            return app;
        }

    }
}
