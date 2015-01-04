using UnityEngine;
using System.Collections;

public class PlayVinyl : MonoBehaviour {

	public float rotSpeed; // degrees per second
	public bool On;
	public bool writing;
	

	// Use this for initialization
	void Start () {
		On = false;
		writing = false;
	}
	
	// Update is called once per frame
	void Update () {

		// User Input
		if(!writing)
		{
			if ( Input.GetKeyDown(KeyCode.Space) ) {
				if(On) { audio.Pause(); }
				else   { audio.Play(); }
				On = !On;
			}

		
			if( On ) { transform.Rotate (0, rotSpeed * Time.deltaTime, 0, Space.World); }
		}

		if( Input.GetKeyDown(KeyCode.L))
		{
			audio.Pause();
		}



	}

	public void stopSpinning(){
		On = false;
		writing = true;
		audio.Pause();
	}

	public void startSpinning(){
		On = true;
		writing = false;
		audio.Play();
	}
}
