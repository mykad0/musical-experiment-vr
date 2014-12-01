using UnityEngine;
using System.Collections;

public class Sequencer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log("start");
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Collision with other GameObjectsCollider
	void OnTriggerEnter (Collider other)
	{
		Debug.Log(other);
		renderer.material.color = Color.yellow;	
	}

	void OnTriggerStay (Collider other)
	{
		// Debug.Log("Object is within the trigger");
	}

	void OnTriggerExit (Collider other)
	{
		// Debug.Log("Object Exited the trigger");
		renderer.material.color = Color.white;
	}
}
