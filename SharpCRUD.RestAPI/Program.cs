using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using SharpCRUD.Domain;
using SharpCRUD.Infrastructure;

namespace SharpCRUD.RestAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var sqlConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(sqlConnectionString))
                throw new ArgumentNullException("ConnectionString need to be specified.");
            
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddInfrastructureLayer(options => { 
               options.UseSqlServer(sqlConnectionString);
            });
            builder.Services.AddDomainLayer();

            var app = builder.Build();

            EnsureDatabaseState(app);

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }

        private static void EnsureDatabaseState(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices
                .GetService<IServiceScopeFactory>().CreateScope();
            var appDbContext = serviceScope.ServiceProvider.GetRequiredService<SharpCrudContext>();

            try
            {
                appDbContext.Database.Migrate();
            }
            catch (Exception)
            {

            }
        }
    }
}