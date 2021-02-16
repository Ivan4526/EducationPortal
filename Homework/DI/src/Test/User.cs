using Newtonsoft.Json;

namespace Entities
{
    public class User
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string AsJson() => JsonConvert.SerializeObject(this);
    }
}
