
using E_commerce.API.Extensions;
using E_commerce.Application;
using E_commerce.Application.Profiles;
using E_commerce.Infrastructure;
using E_Commerce.Domain.Contracts;
using Microsoft.Extensions.FileProviders;
using System.Threading.Tasks;

namespace E_commerce.API
{
    public class Program
    {
        //test
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
           
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddApplicationService();
            builder.Services.AddControllers();
            builder.Services.Configure<UrlSettings>(builder.Configuration.GetSection("UrlSettings"));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
           
            var app = builder.Build();
            await  app.SeadAndMigrateAsync();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles(new StaticFileOptions()
            {
         FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath,"Files")),
         RequestPath = "/Files"
         
            });
           

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
