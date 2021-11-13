namespace Assets.Scripts.Deserializers
{
    public interface IDeserializer
    {
        T Deserialize<T>(string json);
    }
}