using Assets.Scripts.Deserializers;
using System.Collections;
using Assets.Models;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Connectors
{
    public class GetContainersFilesConnect : ConnectBase
    {
        private string Url = EndPoints.GetContainersFiles;

        protected override IEnumerator SendRequest()
        {
            using UnityWebRequest request = UnityWebRequest.Get(Url);
            // Request and wait for the desired page.
            yield return request.SendWebRequest();
            TextMeshPro.text = request.downloadHandler.text;
            _deserializer = new Deserializer();
            _core.GetContainerFilesInput = _deserializer.Deserialize<GetContainerFilesInput>(request.downloadHandler.text);
            //_core.IsUpdateCulture = true;
        }
    }
}