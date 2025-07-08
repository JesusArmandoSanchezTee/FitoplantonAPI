using Application.Interfaces;
using Infrastructure.Persistence.Configuration;
using Infrastructure.Persistence.Repository;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence;

public static class ServiceExtensions
{
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Register your DbContext here
        var conn = configuration.GetConnectionString("MySql");
        services.AddDbContext<ApplicationDbContext>(opts =>
            opts.UseMySql(conn, ServerVersion.AutoDetect(conn),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


        #region Repositories
        services.AddScoped(typeof(IRepositoryAsync<>), typeof(MyRepositoryAsync<>));
        services.AddScoped<IDateTimeService, DateTimeService>();
        #endregion
        // Register other persistence-related services
    }
}