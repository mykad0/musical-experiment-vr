﻿using UnityEngine;
using System.Collections;

public class PlayVinyl : MonoBehaviour {

	public float rotSpeed; // degrees per second
	public bool On;
	public bool writing;

	public int trackplaying;
	

	// Use this for initialization
	void Start () {
		On = false;
		writing = false;
		trackplaying = 1;
		loadTrack();
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

	public void loadTrack() {
		if(trackplaying == 1)
		{	
			transform.collider.gameObject.audio.clip = Resources.Load<AudioClip>("Tank!") as AudioClip;
		}
		else
		{
			transform.collider.gameObject.audio.clip = Resources.Load<AudioClip>("Loop") as AudioClip;
		}
	}

	public void changeTrack() {
		if(trackplaying == 1) { trackplaying = 2;}
		else { trackplaying = 1; }
		loadTrack();
	}

	public void stopSpinning(){
		On = false;
		writing = true;
		audio.Stop();
	}

	public void startSpinning(){
		On = true;
		writing = false;
		audio.Play();
	}
}
