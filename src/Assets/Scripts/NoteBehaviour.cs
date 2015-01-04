using UnityEngine;
using System.Collections;

public class NoteBehaviour : MonoBehaviour {
	public bool activated;
	public AudioSource audioSource;
	public Color startColor;
	public Color activatedColor;

	// Use this for initialization
	void Start () {
		activated = false;
		audioSource = transform.gameObject.AddComponent<AudioSource>();
		startColor = renderer.material.color;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ActivateNote() {
		// Debug.Log("Note Activated" + transform.collider.name);

		int a = transform.collider.name.IndexOf("Track");
		string name = transform.collider.name.Substring(a);
		Debug.Log(name);

		
			if(name == "Track#1") {
				audioSource.clip = Resources.Load<AudioClip>("Hat") as AudioClip;
			}	
			else if( name == "Track#2") {
				audioSource.clip = Resources.Load<AudioClip>("Snare") as AudioClip;
			}
			else if( name == "Track#3") {
				audioSource.clip = Resources.Load<AudioClip>("Clap") as AudioClip;
			}
			else if(name == "Track#4") {
				audioSource.clip = Resources.Load<AudioClip>("KickDrum") as AudioClip;
			}

			if(activated){
				activated = false;
				renderer.material.color = startColor;
			}
			else {
				activated = true;
				renderer.material.color = activatedColor;
			}
	}	
}
