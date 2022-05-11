using Microsoft.Extensions.DependencyInjection;
using OracleApiServer.Utilities.Interfaces;

namespace OracleApiServer.Utilities;
public static class UtilitiesExt
{

    public static bool IsEmpty(this string str) => string.IsNullOrEmpty(str);

    public static void AddUtilityServices( this IServiceCollection services)
    {
        services.AddSingleton<ISystemEnvironment, SystemEnvironment>();
        services.AddSingleton<IJsonFile, JsonFile>();
    }
}