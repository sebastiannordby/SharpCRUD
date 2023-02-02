using Microsoft.Identity.Client;
using SharpCRUD.DataAccess;
using SharpCRUD.Domain;

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
            builder.Services.AddDataAccessLayer(sqlConnectionString);
            builder.Services.AddDomainLayer();

            var app = builder.Build();

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
    }
}