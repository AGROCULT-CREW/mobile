using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Locations
{
    public class GPS : MonoBehaviour, ILocation
    {
        public static GPS Instance { get; set; }
        public TextMeshProUGUI text;

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

            text.text = "Location: "
                        + Input.location.lastData.latitude + " "
                        + Input.location.lastData.longitude + " "
                        + Input.location.lastData.altitude + " "
                        + Input.location.lastData.horizontalAccuracy + " "
                        + Input.location.lastData.timestamp;

            var _latitude = Input.location.lastData.latitude;
            var _longitude = Input.location.lastData.longitude;
            Input.location.Stop();
        }
    }
}