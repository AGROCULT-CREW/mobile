namespace Assets.Scripts.Serializers
{
    public interface ISerializer
    {
        string GetJson<T>(T data);
    }
}