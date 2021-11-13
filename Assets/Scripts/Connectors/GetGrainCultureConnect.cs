using System.Collections;
using System.Collections.Generic;
using Assets.Models;
using Assets.Scripts.Deserializers;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Connectors
{
    public class GetGrainCultureConnect : ConnectBase
    {
        private string Url = EndPoints.GetGrainCulture;

        protected override IEnumerator SendRequest()
        {
            using UnityWebRequest request = UnityWebRequest.Get(Url);
            // Request and wait for the desired page.
            yield return request.SendWebRequest();
            TextMeshPro.text = request.downloadHandler.text;
            _deserializer = new Deserializer();
            _core.GetGrainCultureInput = _deserializer.Deserialize<GetGrainCultureInput>(request.downloadHandler.text);
            //_core.IsUpdateCulture = true;
        }
    }
}