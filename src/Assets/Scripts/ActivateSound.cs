using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActivateSound : MonoBehaviour {
	
	public bool isActivated;
	public AudioSource sound;
	public Color hovercolor;
	public Color startcolor;

	// Start is called just before any of the
	// Update methods is called the first time.
	void Start () {
		sound = null;
		isActivated = false;
	}
	
	// Update is called every frame, if the
	// MonoBehaviour is enabled.
	void Update () {
		
	}

	void SetSound(AudioSource newSound){
		sound = newSound;
	}

	void OnMouseEnter()
	{
		if(!isActivated){
			renderer.material.color = hovercolor;
			//sound.Play();
		}
	}

	void OnMouseDown()
	{
		if(!isActivated){
			Activate();
		} else {
			Deactivate();
		}
	}

	void OnMouseExit()
	{
		if(!isActivated){
			renderer.material.color = startcolor;
		}
		
	}

	void Activate(){
		isActivated = true;
	}

	void Deactivate(){
		isActivated = false;
	}
	
	
}
