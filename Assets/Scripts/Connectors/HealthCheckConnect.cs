using System.Collections;
using System.Collections.Generic;
using Assets.Models;
using Assets.Scripts.Deserializers;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Connectors
{
    public class HealthCheckConnect : ConnectBase
    {
        private string Url = EndPoints.HealthCheck;

        protected override IEnumerator SendRequest()
        {
            using UnityWebRequest request = UnityWebRequest.Get(Url);
            // Request and wait for the desired page.
            yield return request.SendWebRequest();
            TextMeshPro.text = request.downloadHandler.text;
            if (request.result == UnityWebRequest.Result.Success)
            {
                _core.IsHealth = true;
            }
        }
    }
}