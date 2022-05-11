using System.Data;

namespace OracleApiServer.Database.Interfaces;

public interface IDatabaseAccessService
{
    public IDbConnection GetConnection();
    public IDbCommand GetCommand(string sqlOrProcedure = "");
    public IDataReader GetReader(IDbCommand cmd);
    
}