using OracleApiServer.Utilities.Interfaces;

namespace OracleApiServer.Utilities;

public class SystemEnvironment : ISystemEnvironment
{
    public string GetEnv(string name)
    {
        var envVarName = name.ToUpper();
        if (Environment.GetEnvironmentVariables().Contains(envVarName))
        {
            return Environment.GetEnvironmentVariable(envVarName) ?? string.Empty;
        }

        return string.Empty;
    }
}