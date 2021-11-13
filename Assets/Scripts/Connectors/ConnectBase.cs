using System.Collections;
using Assets.Scripts.Deserializers;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Connectors
{
    public abstract class ConnectBase : MonoBehaviour
    {
        public TextMeshProUGUI TextMeshPro;
        protected Core _core = Core.GetCore();
        protected IDeserializer _deserializer;
        
        public void Send()
        {
            StartCoroutine(SendRequest());
        }

        protected abstract IEnumerator SendRequest();
    }
}