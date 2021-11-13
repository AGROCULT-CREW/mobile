using Assets.Models;
using Assets.Scripts.Deserializers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Connectors
{
    public class ConnectUpdateCulture : MonoBehaviour
    {
        private Core _core = Core.GetCore();
        private IDeserializer _deserializer;
        private string Url = EndPoints.GetGrainCultures;

        public void GetUpdate()
        {
            StartCoroutine(SendRequest());
        }

        private IEnumerator SendRequest()
        {
            using (UnityWebRequest request = UnityWebRequest.Get(Url))
            {
                // Request and wait for the desired page.
                yield return request.SendWebRequest();
                _deserializer = new Deserializer();
                _core.Cultures = _deserializer.Deserialize<List<Culture>>(request.downloadHandler.text);
                _core.IsUpdateCulture = true;
            }
        }
    }
}