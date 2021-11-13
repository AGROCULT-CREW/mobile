using Assets.Models;
using Assets.Scripts.Deserializers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Connectors
{
    public class StartContainerProcessingConnect : ConnectBase
    {
        private string Url = EndPoints.StartContainerProcessing;

        protected override IEnumerator SendRequest()
        {
            string json = string.Empty;
            using UnityWebRequest request = UnityWebRequest.Post(Url, json);
            // Request and wait for the desired page.
            yield return request.SendWebRequest();
            TextMeshPro.text = request.downloadHandler.text;
            _deserializer = new Deserializer();
            _core.StartContainerProcessingInput = _deserializer.Deserialize<StartContainerProcessingInput>(request.downloadHandler.text);
            //_core.IsUpdateCulture = true;
        }
    }
}