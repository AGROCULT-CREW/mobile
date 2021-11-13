using System.Collections;
using System.Collections.Generic;
using Assets.Models;
using Assets.Scripts.Deserializers;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Connectors
{
    public class ConnectHealthCheck : MonoBehaviour
    {
        private Core _core = Core.GetCore();
        private IDeserializer _deserializer;
        private string Url = EndPoints.HealthCheck;

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
                if (request.result == UnityWebRequest.Result.Success)
                {
                    _core.IsHealth = true;
                }
            }
        }
    }
}