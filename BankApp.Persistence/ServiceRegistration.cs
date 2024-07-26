using BankApp.Persistence.Contexts;
using BankApp.Persistence.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoSettings>(options =>
        {                                                                                                                   //mongo entegre
            options.ConnectionString = configuration.GetSection("MongoConnection:ConnectionString").Value;
            options.Database = configuration.GetSection("MongoConnection:Database").Value;
        });

        services.AddSingleton<MongoDbContext>();

       
    }
}
