using Oracle.ManagedDataAccess.Types;
using OracleApiServer.Database.Interfaces;

namespace OracleApiServer.Database.Services;

public class DatabaseCoreService : IDatabaseCoreService
{
    private readonly IDatabaseAccessService _accessService;

    public DatabaseCoreService(IDatabaseAccessService accessService)
    {
        _accessService = accessService;
    }

    public DateTime GetDatabaseServerTime()
    {
        using var cmd = _accessService.GetCommandSql("SELECT SYSDATE AS DT FROM DUAL");
        using var rdr = _accessService.GetReader(cmd);
        var read = rdr.Read();
        return (DateTime) rdr["DT"];
    }
}