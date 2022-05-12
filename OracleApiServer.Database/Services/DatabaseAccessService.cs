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

    public OracleConnection GetConnection() => new(_configManager.GetConnectionString());
    public OracleCommand GetCommand()
    {
        var conn = this.GetConnection();
        conn.Open();
        var cmd = conn.CreateCommand();
        return cmd;
    }

    public OracleCommand GetCommandSql(string sql)
    {
        var cmd = GetCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = sql;
        return cmd;
    }

    public OracleCommand GetCommandProcedure(string procedure)
    {
        var cmd = GetCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = procedure;
        return cmd;
    }

    public OracleDataReader GetReader(OracleCommand cmd) => cmd.ExecuteReader();
}