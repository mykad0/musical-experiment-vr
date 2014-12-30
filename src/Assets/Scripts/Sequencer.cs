using UnityEngine;
using System.Collections;

public class Sequencer : MonoBehaviour {

	public Color startColor;
	// Use this for initialization
	void Start () {
		Debug.Log("start");
	
	}
	
	// Update is called once per frame
	void Update () {
		startColor = GameObject.Find("Note#0").renderer.material.color;
	}

	// Collision with other GameObjectsCollider
	void OnTriggerEnter (Collider other)
	{
		Debug.Log(other);
		other.renderer.material.color = Color.cyan;
		other.audio.Play ();
	}

	void OnTriggerExit (Collider other)
	{
		// Debug.Log("Object Exited the trigger");
		renderer.material.color = startColor;
	}
}
