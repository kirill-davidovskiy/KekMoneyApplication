using Microsoft.EntityFrameworkCore;
using SmithTrade.repository;

namespace SmithTrade
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var configuration =  new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json")
                .Build();
            
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddDbContext<WalletRepository>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("DatabaseConnection")));
            builder.Services.AddDbContext<UserRepository>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("DatabaseConnection")));
            builder.Services.AddDbContext<TransferRepository>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("DatabaseConnection")));
            
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();
            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
            
            
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });

            app.Run();
        }
    }
}