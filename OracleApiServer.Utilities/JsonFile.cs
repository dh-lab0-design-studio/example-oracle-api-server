using System.Text.Json;
using OracleApiServer.Utilities.Interfaces;

namespace OracleApiServer.Utilities;

public class JsonFile : IJsonFile
{
    public void WriteJsonFile<TObject>(string fileName, TObject obj) => 
        File.WriteAllText(fileName, JsonSerializer.Serialize(obj));

    public TObject ReadJsonFile<TObject>(string fileName) where TObject : new() => 
        JsonSerializer.Deserialize<TObject>(File.ReadAllText(fileName)) ?? new TObject();
}