using System.IO;
using Newtonsoft.Json;
using SRP.Solution.Serialization;

namespace SRP.Solution
{
    public class JsonSerializer : ISerializer
    {
        public void SaveToFile<T>(T obj, string filename)
        {
            var json = JsonConvert.SerializeObject(obj);

            File.WriteAllText(filename, json);
        }

        public T LoadFromFile<T>(string filename)
        {
            var json = File.ReadAllText(filename);

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}