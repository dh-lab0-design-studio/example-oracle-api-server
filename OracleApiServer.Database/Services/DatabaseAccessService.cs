using System.Data;
using Oracle.ManagedDataAccess.Client;
using OracleApiServer.Database.Interfaces;
using OracleApiServer.Utilities;

namespace OracleApiServer.Database.Services;

public class DatabaseAccessService : IDatabaseAccessService
{
    private readonly IDatabaseConfigManager _configManager;

    public DatabaseAccessService(IDatabaseConfigManager configManager)
    {
        _configManager = configManager;
    }

    public IDbConnection GetConnection() => new OracleConnection(_configManager.GetConnectionString());
    public IDbCommand GetCommand(string sqlOrProcedure = "")
    {
        var conn = this.GetConnection();
        conn.Open();
        var cmd = conn.CreateCommand();
        if (sqlOrProcedure.IsEmpty()) return cmd;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = sqlOrProcedure;
        return cmd;
    }

    public IDataReader GetReader(IDbCommand cmd)
    {
        return cmd.ExecuteReader();
    }
}