using UnityEngine;
using System.Collections;

public class SwitchMode : MonoBehaviour {

	public bool playMode;
	public bool debug;
	public float smoothFactor = 15f;
	private bool moving = false;
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
					//Quaternion rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
					//rotation *= Quaternion.Euler(0,-90,0);
					//transform.rotation = Quaternion.Slerp(transform.rotation, rotation, smoothFactor*Time.deltaTime);
					if(!moving){
						StartCoroutine(MoveToWriting());
					}
					//transform.Rotate (-90, 0, 0, Space.World);
					//transform.Translate (0, 2, 2, Space.World);
					playMode = ! playMode;
				} else {
					//transform.Rotate (90, 0, 0, Space.World);
					//transform.Translate (0, -2, -2, Space.World);
					
					if(!moving){
						StartCoroutine(MoveToPlay());
					}
					playMode = ! playMode;
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
					if(!moving){
						StartCoroutine(MoveToWriting());
					}
					playMode = ! playMode;
				} 
			} else if (gestureListener.IsSwipeDown()) {
				if (!playMode) {
					if(!moving){
						StartCoroutine(MoveToPlay());
					}
					playMode = ! playMode;
				}
			}
		}
	}

	IEnumerator MoveToPlay (){
		moving = true; // MoveObject started
		float i = 0;
		while (i < 1) {
			i += smoothFactor*Time.deltaTime;

			Quaternion startRot = transform.rotation;
			Quaternion endRot = Quaternion.AngleAxis(90, Vector3.up);
			Vector3 startPos = transform.position;
			Vector3 endPos = new Vector3(0,0,0);

			transform.rotation = Quaternion.Slerp(startRot, endRot, i);
			transform.position = Vector3.Lerp(startPos, endPos, i);
			yield return 0;
		}
		moving = false; // MoveObject ended
		play.startSpinning();
	}


	IEnumerator MoveToWriting (){
		moving = true; // MoveObject started
		float i = 0;
		play.stopSpinning();
		while (i < 1) {
			i += smoothFactor*Time.deltaTime;

			Quaternion startRot = transform.rotation;
			Quaternion endRot = Quaternion.AngleAxis(-90, Vector3.right);
			Vector3 startPos = transform.position;
			Vector3 endPos = new Vector3(0,10,10);

			transform.rotation = Quaternion.Slerp(startRot, endRot, i);
			transform.position = Vector3.Lerp(startPos, endPos, i);
			yield return 0;
		}
		moving = false; // MoveObject ended
	}
}