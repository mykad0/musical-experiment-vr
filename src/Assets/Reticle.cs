using UnityEngine;
using System.Collections;

public class Reticle : MonoBehaviour {
	public Camera CameraFacing;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = CameraFacing.transform.position + CameraFacing.transform.rotation * Vector3.forward * 2.0f;
		transform.LookAt(CameraFacing.transform.position);
		transform.Rotate(0.0f, 180.0f, 0.0f);

		RaycastHit hit;
		Ray ray = new Ray(CameraFacing.transform.position,CameraFacing.transform.rotation * Vector3.forward * 10.0f);
		float distance;

		Debug.DrawRay(CameraFacing.transform.position, CameraFacing.transform.rotation * Vector3.forward * 10.0f, Color.green);

		if (Physics.Raycast( ray, out hit))
		{
			if(hit.collider.tag == "Note")
			{
				Debug.Log(hit.collider.name);
				Debug.Log("note");
				Debug.DrawLine(CameraFacing.transform.position, hit.point, Color.yellow, 5);
			} 
		}
	}
}
