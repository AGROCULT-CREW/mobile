using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Locations
{
    public class GPS : MonoBehaviour, ILocation
    {
        public static GPS Instance { get; set; }
        public TMP_InputField _latitude;
        public TMP_InputField _longitude;

        void Start()
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            StartCoroutine(LocationCoroutine());
        }

        public void GetLoc()
        {
            StartCoroutine(LocationCoroutine());
        }

        IEnumerator LocationCoroutine()
        {
            yield return new WaitForSecondsRealtime(5);
            if (!Input.location.isEnabledByUser)
            {
                yield break;
            }
            
            Input.location.Start(0.1f, 0.1f);
            
            int maxWait = 15;
            while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
            {
                yield return new WaitForSecondsRealtime(1);
                maxWait--;
            }
            
            if (maxWait < 1)
            {
                yield break;
            }
            
            if (Input.location.status != LocationServiceStatus.Running)
            {
                yield break;
            }
            _latitude.text = Input.location.lastData.latitude.ToString();
            _longitude.text = Input.location.lastData.longitude.ToString();
            Input.location.Stop();
        }
    }
}