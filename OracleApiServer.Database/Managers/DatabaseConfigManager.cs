using Microsoft.Extensions.Hosting;
using Oracle.ManagedDataAccess.Client;
using OracleApiServer.Database.Config;
using OracleApiServer.Database.Interfaces;
using OracleApiServer.Utilities;
using OracleApiServer.Utilities.Interfaces;

namespace OracleApiServer.Database.Managers;

public class DatabaseConfigManager : IDatabaseConfigManager
{
    private readonly IJsonFile _configJson;
    private readonly IHostEnvironment _hostingEnvironment;
    private readonly ISystemEnvironment _env;
    public DatabaseConfigManager(IHostEnvironment hostingEnvironment, IJsonFile configJson, ISystemEnvironment env)
    {
        _hostingEnvironment = hostingEnvironment;
        _configJson = configJson;
        _env = env;
    }

    private (bool isSuccess, DatabaseAccessConfig config) ConfigureFromEnv()
    {
        var cfg = new DatabaseAccessConfig
        {
            TnsAdmin = _env.GetEnv("TNS_ADMIN"),
            OracleDatabase = _env.GetEnv("ORACLE_DB"),
            OracleUser = _env.GetEnv("ORACLE_USER"),
            OraclePassword = _env.GetEnv("ORACLE_PASSWORD")
        };
        var cfgSuccess = !cfg.TnsAdmin.IsEmpty()
                         || !cfg.OracleDatabase.IsEmpty()
                         || !cfg.OracleUser.IsEmpty();


        return (cfgSuccess, cfg);
    }
    public string GetConnectionString()
    {
        var config = DbConfig;
        return new OracleConnectionStringBuilder()
        {
            DataSource = config.OracleDatabase,
            UserID = config.OracleUser,
            Password = config.OraclePassword
        }.ConnectionString;
    }

    private DatabaseAccessConfig? _dbConfig = null;
    private DatabaseAccessConfig DbConfig
    {
        get
        {
            if (_dbConfig != null)
            {
                return _dbConfig;
            }
            
            
            var (envConfigSuccess, config) = ConfigureFromEnv();
            if (!envConfigSuccess)
            {
                config = _configJson.ReadJsonFile<DatabaseAccessConfig>(ConfigFileName);
            }

            _dbConfig = config;
            OracleConfiguration.TnsAdmin = _dbConfig.TnsAdmin;
            return _dbConfig;
        }
    }

    private string ConfigFileName =>
        Path.Combine(_hostingEnvironment.ContentRootPath,
            "appsettings.Database.json");
}