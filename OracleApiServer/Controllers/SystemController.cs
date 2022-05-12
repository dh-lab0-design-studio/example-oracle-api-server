using System.Globalization;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using OracleApiServer.Database.Interfaces;
using OracleApiServer.Models;

namespace OracleApiServer.Controllers;

public class SystemController : BaseApiController
{
    private IDatabaseCoreService _core;

    private ICountriesQueryService _countries;
    public SystemController(IDatabaseCoreService core, ICountriesQueryService countries)
    {
        _core = core;
        _countries = countries;
    }

    [HttpGet("s")]
    public JsonOutput GetConnectString()
    {
        var trim = _countries.GetCountries().Trim();
        return JsonSerializer.Deserialize<JsonOutput>(trim) ?? new JsonOutput();
    }
}