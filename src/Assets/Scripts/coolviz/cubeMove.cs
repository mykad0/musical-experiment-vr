using UnityEngine;
using System.Collections;

public class cubeMove : MonoBehaviour {
	public	float		rotCte;
	
	void Update ()
	{
		transform.Rotate(new Vector3(rotCte * Time.deltaTime, rotCte / 2.0f * Time.deltaTime, rotCte / 4.0f * Time.deltaTime));
	}
}
