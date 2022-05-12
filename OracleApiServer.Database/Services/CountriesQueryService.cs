using System.Data;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using OracleApiServer.Database.Interfaces;

namespace OracleApiServer.Database.Services;

public class CountriesQueryService : ICountriesQueryService
{
    private readonly IDatabaseAccessService _access;

    public CountriesQueryService(IDatabaseAccessService access)
    {
        _access = access;
    }

    public string GetCountries()
    {
        using var cmdGetCountries = _access.GetCommandProcedure("GET_COUNTRIES");
        var outParam = new OracleParameter("P_JSON_OUT", OracleDbType.Clob, ParameterDirection.Output);
        cmdGetCountries.Parameters.Add(outParam);
        cmdGetCountries.ExecuteNonQuery();
        return ((OracleClob)outParam.Value).Value;
    }
}