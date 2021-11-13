using UnityEngine;
using System.Collections;
using Platform.Android;
using TMPro;

public class Example : MonoBehaviour
{
    public TextMeshProUGUI pro;

	public void GetPerm()
	{
		//GetComponent<PermissionProvider> ().VerifyStorage (hasBeenGranted => pro.text ="Storage permissions granted: " + hasBeenGranted);
		GetComponent<PermissionProvider> ().VerifyInternet(hasBeenGranted => pro.text ="Storage permissions granted: " + hasBeenGranted);
	}
}
