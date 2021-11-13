using System.Collections;
using System.Collections.Generic;
using Assets.Models;
using Assets.Scripts.Deserializers;
using UnityEngine.Networking;

namespace Assets.Scripts.Connectors
{
    public class CreateContainerConnect : ConnectBase
    {
        private string Url = EndPoints.CreateContainer;

        protected override IEnumerator SendRequest()
        {
            string json = string.Empty;
            using UnityWebRequest request = UnityWebRequest.Post(Url, json);
            // Request and wait for the desired page.
            yield return request.SendWebRequest();
            TextMeshPro.text = request.downloadHandler.text;
            _deserializer = new Deserializer();
            _core.CreateContainerInput = _deserializer.Deserialize<CreateContainerInput>(request.downloadHandler.text);
            //_core.IsUpdateCulture = true;
        }
    }
}