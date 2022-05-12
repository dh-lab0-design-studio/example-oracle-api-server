using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace OracleApiServer.Database.Interfaces;

public interface IDatabaseAccessService
{
    public OracleConnection GetConnection();
    public OracleCommand GetCommand();
    public OracleCommand GetCommandSql(string sql);
    public OracleCommand GetCommandProcedure(string procedure);
    public OracleDataReader GetReader(OracleCommand cmd);
    
}