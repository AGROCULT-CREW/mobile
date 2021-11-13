using Newtonsoft.Json;

namespace Assets.Scripts.Deserializers
{
    public class Deserializer : IDeserializer
    {
        public T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}