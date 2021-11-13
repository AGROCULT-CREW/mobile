using Assets.Models;
using Assets.Scripts.Deserializers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Connectors
{
    public class GetGrainCulturesConnect : ConnectBase
    {
        private string Url = EndPoints.GetGrainCultures;

        protected override IEnumerator SendRequest()
        {
            using UnityWebRequest request = UnityWebRequest.Get(Url);
            // Request and wait for the desired page.
            yield return request.SendWebRequest();
            TextMeshPro.text = request.downloadHandler.text;
            _deserializer = new Deserializer();
            _core.Cultures = _deserializer.Deserialize<List<CultureInput>>(request.downloadHandler.text);
            _core.IsUpdateCulture = true;
        }
    }
}