using UnityEngine;
using System.Collections;

public class PlayVinyl : MonoBehaviour {

	public float rotSpeed; // degrees per second
	public bool On;

	// Use this for initialization
	void Start () {
		On = false;
		rotSpeed = 90;	
	}
	
	// Update is called once per frame
	void Update () {
		// User Input
		if ( Input.GetKeyDown(KeyCode.Space) ) {
			On = !On;
			audio.Play ();
		}
		
		if( On ) { transform.Rotate (0, rotSpeed * Time.deltaTime, 0, Space.World); }
	}

	public void stopSpinning(){
		On = false;
	}

	public void startSpinning(){
		On = true;
	}
}
