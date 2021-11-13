using Assets.Scripts.Deserializers;
using System.Collections;
using Assets.Models;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Connectors
{
    public class GetContainerConnect : ConnectBase
    {
        private string Url = EndPoints.GetContainer;
        
        protected override IEnumerator SendRequest()
        {
            using UnityWebRequest request = UnityWebRequest.Get(Url);
            // Request and wait for the desired page.
            yield return request.SendWebRequest();
            TextMeshPro.text = request.downloadHandler.text;
            _deserializer = new Deserializer();
            _core.GetContainerInput = _deserializer.Deserialize<GetContainerInput>(request.downloadHandler.text);
            //_core.IsUpdateCulture = true;
        }
    }
}