using UnityEngine;
using System.Collections;

public class SwitchMode : MonoBehaviour {

	public bool playMode;
	public bool debug;
	KinectVinylGestureListener gestureListener;
	PlayVinyl play;

	// Use this for initialization
	void Start () {
		playMode = true;
		gestureListener = Camera.main.GetComponent<KinectVinylGestureListener>();
		play = GetComponentInParent<PlayVinyl> ();
	}
	
	bool ToPlayMode(){
		return true;
	}

	bool ToWritingMode(){
		return false;
	}

	// Update is called once per frame
	void Update () {
		if(debug){
			if (Input.GetKeyDown(KeyCode.M)) {
				if (playMode) {
					play.stopSpinning();
					transform.Rotate (-90, 0, 0, Space.World);
					transform.Translate (0, 2, 2, Space.World);
					playMode = ! playMode;
				} else {
					transform.Rotate (90, 0, 0, Space.World);
					transform.Translate (0, -2, -2, Space.World);
					playMode = ! playMode;
					play.startSpinning();
				}
			}

		} else {
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
}
