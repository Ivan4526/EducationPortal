namespace SRP.Solution.Serialization
{
    public interface ISerializer
    {
        void SaveToFile<T>(T obj, string filename);

        T LoadFromFile<T>(string filename);
    }
}