using System.Data;
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
        using var cmdGetCountries = _access.GetCommand();
        cmdGetCountries.CommandText = "GET_COUNTRIES";
        cmdGetCountries.CommandType = CommandType.StoredProcedure;
        var outParam = cmdGetCountries.CreateParameter();
        outParam.Direction = ParameterDirection.Output;
        outParam.DbType = DbType.String;
        outParam.ParameterName = "P_JSON_OUT";
        outParam.Size = 32767;
        cmdGetCountries.Parameters.Add(outParam);
        cmdGetCountries.ExecuteNonQuery();
        return outParam.Value?.ToString() ?? string.Empty;
    }
}