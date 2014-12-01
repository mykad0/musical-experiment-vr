using UnityEngine;
using System.Collections;

public class SwitchMode : MonoBehaviour {

	public bool playMode;

	// Use this for initialization
	void Start () {
		playMode = false;
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetKeyDown(KeyCode.M) ) {
			if(playMode){
				transform.Rotate (-90,0,0,Space.World);
				transform.Translate (0,2,2,Space.World);
			} else {
				transform.Rotate (90,0,0,Space.World);
				transform.Translate (0,-2,-2,Space.World);
			}
			playMode = ! playMode;
		}
	}
}
