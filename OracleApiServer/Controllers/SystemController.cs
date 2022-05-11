using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using OracleApiServer.Database.Interfaces;

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
    public string GetConnectString()
    {
        return _countries.GetCountries();
    }
}