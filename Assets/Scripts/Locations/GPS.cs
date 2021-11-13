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

            text.text += "Запуск 0\n";
            //NativeCamera.RequestPermission("LocationPermission");

            StartCoroutine(LocationCoroutine());
        }

        public void GetLoc()
        {
            if (Input.location.status != LocationServiceStatus.Running)
            {
                text.text += "Не запущена\n";
            }
            else
            {
                text.text = "Location: "
                            + Input.location.lastData.latitude + " "
                            + Input.location.lastData.longitude + " "
                            + Input.location.lastData.altitude + " "
                            + Input.location.lastData.horizontalAccuracy + " "
                            + Input.location.lastData.timestamp;
            }
        }

        IEnumerator LocationCoroutine()
        {
            text.text += "Запуск 2\n";
            yield return new WaitForSecondsRealtime(10);
            // First, check if user has location service enabled
            if (!Input.location.isEnabledByUser)
            {
                text.text += "Запуск 3\n";
                //yield break;
            }

            // Start service before querying location
            Input.location.Start(0.1f, 0.1f);

            // Wait until service initializes
            int maxWait = 15;
            while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
            {
                text.text += "Запуск 4\n";
                yield return new WaitForSecondsRealtime(1);
                maxWait--;
            }


            // Service didn't initialize in 15 seconds
            if (maxWait < 1)
            {
                text.text += "Запуск 5\n";
                yield break;
            }

            // Connection has failed
            if (Input.location.status != LocationServiceStatus.Running)
            {
                text.text += "Запуск 6\n";
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

            text.text += "Запуск 7\n";
            // Stop service if there is no need to query location updates continuously
            Input.location.Stop();
        }
    }
}