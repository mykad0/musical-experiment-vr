using UnityEngine;
using System.Collections;

public class SwitchMode : MonoBehaviour {

	public bool playMode;
	VinylGestureListener gestureListener;
	PlayVinyl play;

	// Use this for initialization
	void Start () {
		playMode = true;
		gestureListener = Camera.main.GetComponent<VinylGestureListener>();
		play = GetComponentInParent<PlayVinyl> ();
	}
	
	// Update is called once per frame
	void Update () {
				//Check if user is connected
				KinectManager kinectManager = KinectManager.Instance;
				if (!kinectManager
						|| !kinectManager.IsInitialized ()
						|| !kinectManager.IsUserDetected ())
						return;

				if (gestureListener.IsSwipeUp()) {
						if (playMode) {
								play.stopSpinning();
								transform.Rotate (-90, 0, 0, Space.World);
								transform.Translate (0, 2, 2, Space.World);
								playMode = ! playMode;
						} 
				} else if (gestureListener.IsSwipeDown()) {
						if (!playMode) {
								transform.Rotate (90, 0, 0, Space.World);
								transform.Translate (0, -2, -2, Space.World);
								playMode = ! playMode;
								play.startSpinning();
						}
				}

		}
}
