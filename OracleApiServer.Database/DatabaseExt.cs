using Microsoft.Extensions.DependencyInjection;
using OracleApiServer.Database.Interfaces;
using OracleApiServer.Database.Managers;
using OracleApiServer.Database.Services;
using OracleApiServer.Utilities;

namespace OracleApiServer.Database;
public static class DatabaseExt
{

    public static void AddDatabaseServices(this IServiceCollection services)
    {
        services.AddSingleton<IDatabaseConfigManager, DatabaseConfigManager>();
        services.AddSingleton<IDatabaseAccessService, DatabaseAccessService>();
        services.AddSingleton<IDatabaseCoreService, DatabaseCoreService>();
        services.AddSingleton<ICountriesQueryService, CountriesQueryService>();
        services.AddUtilityServices();
    }
}
