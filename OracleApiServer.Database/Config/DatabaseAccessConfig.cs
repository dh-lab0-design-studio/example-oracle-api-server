namespace OracleApiServer.Database.Config;

public class DatabaseAccessConfig
{
    public string TnsAdmin { get; init; } = "";
    public string OracleDatabase { get; init; } = "";
    public string OracleUser { get; init; } = "";
    public string OraclePassword { get; init; } = "";
}