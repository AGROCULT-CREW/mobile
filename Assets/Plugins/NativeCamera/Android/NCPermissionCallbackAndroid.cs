#if UNITY_EDITOR || UNITY_ANDROID
using System.Threading;
using UnityEngine;

namespace NativeCameraNamespace
{
	public class NCPermissionCallbackAndroid : AndroidJavaProxy
    {
        private static string formate = "com.yasirkula.unity.{0}Receiver";
		private object threadLock;
		public int Result { get; private set; }

		public NCPermissionCallbackAndroid( object threadLock, string line) : base( string.Format(formate, line) )
		{
			Result = -1;
			this.threadLock = threadLock;
		}

		public void OnPermissionResult( int result )
		{
			Result = result;

			lock( threadLock )
			{
				Monitor.Pulse( threadLock );
			}
		}
	}
}
#endif