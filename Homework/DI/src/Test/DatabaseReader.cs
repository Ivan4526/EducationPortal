using System.Threading;

public class DatabaseReader
{
    private readonly Mutex mutex = 
        new Mutex(initiallyOwned: false, name: "Global\\DB");

    public object[] Read()
    {
        this.mutex.WaitOne();

        // read data
        var data = new object[0];

        this.mutex.ReleaseMutex();

        return data;
    }
}

public class DatabaseWriter
{
    private readonly Mutex mutex = new Mutex(initiallyOwned: false, name: "Global\\DB");

    public void Write(object[] data)
    {
        this.mutex.WaitOne();

        // write data

        this.mutex.ReleaseMutex();
    }
}