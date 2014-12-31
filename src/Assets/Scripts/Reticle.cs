using UnityEngine;
using System.Collections;

public class Reticle : MonoBehaviour {
	public Camera CameraFacing;
	public GameObject prevCastTrack;

	// Use this for initialization
	void Start () {
		prevCastTrack = GameObject.Find("Track#1");
	}
	
	// Update is called once per frame
	void Update () {

		/* Compute the right orientation for the reticle at all times */
		transform.position = CameraFacing.transform.position + CameraFacing.transform.rotation * Vector3.forward * 2.0f;
		transform.LookAt(CameraFacing.transform.position);
		transform.Rotate(0.0f, 180.0f, 0.0f);

		/* Raycast Action */
		RaycastHit hit;
		Ray ray = new Ray(CameraFacing.transform.position,CameraFacing.transform.rotation * Vector3.forward * 10.0f);
		 
		Debug.DrawRay(CameraFacing.transform.position, CameraFacing.transform.rotation * Vector3.forward * 10.0f, Color.red);

		if (Physics.Raycast( ray, out hit))
		{
			/* If a track is hit by the ray */
			if(hit.collider.tag == "Track") 
			{
				/* Debug */	      
				Debug.DrawLine(CameraFacing.transform.position, hit.point, Color.cyan, 1);
				// Debug.Log(hit.collider.name);       

				/* Handle Mouse Simulation, might consider caching all the track gameObjects for performance */
				if(hit.collider.name != prevCastTrack.name)
				{
					prevCastTrack.GetComponent("HighlightOnHover").SendMessage("OnMouseExit", SendMessageOptions.DontRequireReceiver);
				}


				if (Input.GetMouseButtonDown(0))
				{
					hit.collider.GetComponent("HighlightOnHover").SendMessage("OnMouseDown", SendMessageOptions.DontRequireReceiver);
				}

				hit.collider.GetComponent("HighlightOnHover").SendMessage("OnMouseEnter", SendMessageOptions.DontRequireReceiver);
				
				prevCastTrack = hit.collider.gameObject;
			}

			/* If a note is hit by the ray */
			if(hit.collider.tag == "Note")
			{
				// Debug.Log(hit.collider.name);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
				Debug.DrawLine(CameraFacing.transform.position, hit.point, Color.yellow, 5);

				if (Input.GetMouseButtonDown(0))
				{
					// hit.collider.gameObject.audio.Play();
					/* Might consider caching all the note gameObjects for performance */
					// GameObject.Find(hit.collider.name).SendMessage("HandleNote");
				}
			} 
		}
	}

 	 
	/* Note Message */
	void HandleNote() {
		audio.Play();
	}
}
