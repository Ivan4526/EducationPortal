using System.Data;

public interface IDbProvider
{
    DataTable Read(string tableName);

    void Write(string tableName, DataRow[] records);
}

public class ReadOnlyDatabase : IDbProvider
{
    public DataTable Read(string tableName)
    {
        // read data
        return new DataTable();
    }

    public void Write(string tableName, DataRow[] records)
    {
        // do nothing
    }
}