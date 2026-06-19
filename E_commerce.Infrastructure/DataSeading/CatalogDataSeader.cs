using E_commerce.Infrastructure.Data;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_commerce.Infrastructure.DataSeading
{
    internal class CatalogDataSeader(StoreDbContext storeDbContext , ILogger<CatalogDataSeader> logger) : IDataSeader
    {
        public async Task DataSeadAsync(CancellationToken ct)
        {

            try
            {
                var PendingMigrations = await storeDbContext.Database.GetPendingMigrationsAsync();
                if (PendingMigrations.Any())
                {
                    logger.LogInformation($"Applied #{PendingMigrations.Count()} Pending Migrations");
                    await storeDbContext.Database.MigrateAsync();
                }
                // base ditectory + DataSead
                var rootPath = Path.Combine(AppContext.BaseDirectory, "DataSead");
                await SeadIfEmptyAsync<ProductBrand, int>(rootPath, "brands.json", ct);
                await SeadIfEmptyAsync<ProductType, int>(rootPath, "types.json", ct);
                await SeadIfEmptyAsync<Product, int>(rootPath, "products.json", ct);
              var res =  await  storeDbContext.SaveChangesAsync(ct);

                if(res >0)
                {
                    logger.LogInformation("Data Seaded Sucessfully");
                }
                else
                {
                    logger.LogInformation("Data Already Seaded");
                }



            }catch(Exception ex)
            {

            }


            
           
        }

       private async Task SeadIfEmptyAsync<T,Tkey>(string rootPath , string fileName,CancellationToken ct) where T : BaseEntity<Tkey>
        {
            var fullpath = Path.Combine(rootPath, fileName);
          
            if(await storeDbContext.Set<T>().AnyAsync())
            {
                logger.LogInformation("Table Already has data");
                return;
            }

           using var fileStream = File.OpenRead(fullpath);
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };

          var items = await JsonSerializer.DeserializeAsync<List<T>>(fileStream, options);

            if(items?.Any() ?? false)
            {
               storeDbContext.Set<T>().AddRange(items);
            }

        }
    }
}
