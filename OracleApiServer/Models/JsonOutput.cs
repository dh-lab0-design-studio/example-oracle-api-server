using System.Text.Json;
using System.Text.Json.Nodes;

namespace OracleApiServer.Models;

public class JsonOutput
{
    public JsonObject[] Items { get; set; } 
}