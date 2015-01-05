using UnityEngine;
using System.Collections;

public class NoteBehaviour : MonoBehaviour {
	public bool activated;
	public Color startColor;
	public Color activatedColor;

	// Use this for initialization
	void Start () {
		activated = false;
		startColor = renderer.material.color;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ActivateNote() {
		int a = transform.collider.name.IndexOf("Track");
		string name = transform.collider.name.Substring(a);
		
		Debug.Log(transform.collider.name);
		
		if(transform.gameObject.audio.mute){
			transform.gameObject.audio.mute = false;
			Debug.Log("pas mute" + transform.gameObject.audio.mute);
			renderer.material.color = activatedColor;
			/*activated = true;renderer.material.color = activatedColor
			renderer.material.color = activatedColor;*/
		}
		else {
			transform.gameObject.audio.mute = true;
			Debug.Log("muted" + transform.gameObject.audio.mute);
			renderer.material.color = startColor;
			/*
			audioSource.mute = !audioSource.mute;
			activated = false;
			renderer.material.color = startColor;*/
		}
 
	}	
}
