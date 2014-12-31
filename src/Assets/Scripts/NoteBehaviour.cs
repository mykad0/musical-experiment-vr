using UnityEngine;
using System.Collections;

public class NoteBehaviour : MonoBehaviour {
	public bool activated;
	// Use this for initialization
	void Start () {
		activated = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Activate() {
		if(activated){
			activated = false;
		}
		else
			activated = true;
	}
}
