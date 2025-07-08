using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;       
using Infrastructure.Services;                   

namespace Infrastructure.Persistence.Configuration
{
    public class DesignTimeDbContextFactory
      : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // 1) Lee appsettings.json (y opcionalmente appsettings.Development.json)
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
            var basePath = Directory.GetCurrentDirectory();
            var config = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            // 2) Toma la cadena de conexión
            var conn = config.GetConnectionString("MySql");

            // 3) Construye las opciones de DbContext
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseMySql(
                conn,
                ServerVersion.AutoDetect(conn),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
            );

            // 4) Crea una instancia de tu IDateTimeService
            var clock = new DateTimeService();            // <- ver paso 3

            // 5) Devuelve tu contexto inyectando las opciones y el clock
            return new ApplicationDbContext(optionsBuilder.Options, clock);
        }
    }
}
