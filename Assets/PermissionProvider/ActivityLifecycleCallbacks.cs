using UnityEngine;
using System.Collections;
using System;
using Platform.Android.Stubs;

namespace Platform.Android {

	public class ActivityLifecycleCallbacks : MonoBehaviour
	{
		public static event Action OnCreate;
		public static event Action OnStart;
		public static event Action OnResumed;
		public static event Action OnPause;
		public static event Action OnStop;
		public static event Action OnSavedInstanceState;
		public static event Action OnDestroyed;

		#if UNITY_ANDROID && !UNITY_EDITOR
		
		private AndroidJavaObject _lifeCycle;
		
		public  AndroidJavaObject LifeCycle { 
			get { 
				if (_lifeCycle == null)
					_lifeCycle = new AndroidJavaObject ("net.kibotu.unity.android.lifecycle.UnityActivityLifeCycleCallbacks", gameObject.name);
				return _lifeCycle;
			} 
		}
		
		#else
		
		public static AndroidJavaObjectStub LifeCycle = new AndroidJavaObjectStub();
		
		#endif

		void Awake() {
			LifeCycle.Call("init");
		}

		public void onActivityCreated(string unused) {
			Debug.Log ("[onActivityCreated]");
			if(OnCreate != null)
				OnCreate();
		}

		public void onActivityStarted(string unused) {
			Debug.Log ("[onActivityStarted]");
			if(OnStart != null)
				OnStart();
		}

		public void onActivityResumed(string unused) {
			Debug.Log ("[onActivityResumed]");
			if(OnResumed != null)
				OnResumed();
		}

		public void onActivityPaused(string unused) {
			Debug.Log ("[onActivityPaused]");
			if(OnPause != null)
				OnPause();
		}

		public void onActivityStopped(string unused) {
			Debug.Log ("[onActivityStopped]");
			if(OnStop != null)
				OnStop();
		}

		public void onActivitySaveInstanceState(string unused) {
			Debug.Log ("[onActivitySaveInstanceState]");
			if(OnSavedInstanceState != null)
				OnSavedInstanceState();
		}	

		public void onActivityDestroyed(string unused) {
			Debug.Log ("[onActivityDestroyed]");
			if(OnDestroyed != null)
				OnDestroyed();
		}
	}
}