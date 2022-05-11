namespace OracleApiServer.Utilities.Interfaces;

public interface IJsonFile
{
    public void WriteJsonFile<TObject>(string fileName, TObject obj);
    public TObject ReadJsonFile<TObject>(string fileName)  where TObject : new();
}