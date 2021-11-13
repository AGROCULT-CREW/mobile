using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Assets.Scripts.Serializers
{
    public class Serializer : ISerializer
    {
        public string GetJson<T>(T data)
        {
            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            ser.WriteObject(ms, data);
            byte[] json = ms.ToArray();
            ms.Close();
            return Encoding.UTF8.GetString(json, 0, json.Length);
        }
    }
}