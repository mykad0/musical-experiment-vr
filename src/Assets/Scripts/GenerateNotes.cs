using UnityEngine;
using System.Collections;

public class GenerateNotes : MonoBehaviour {

	public int nbNotes;
	private double rayonInf;
	private double rayonSup;

	// Use this for initialization
	void Start () {
		float stepAngle = 360/nbNotes;
		float angle = 0;
		//rayonSup =
		//rayonInf =
		for(int i=0;i<nbNotes;i++){
			int x = (int) (rayonInf*Mathf.Cos(angle) + rayonSup*Mathf.Cos(angle))/2;
			int y = (int) (rayonInf*Mathf.Sin(angle) + rayonSup*Mathf.Sin(angle))/2;
			GameObject.CreatePrimitive(PrimitiveType.Sphere);
			
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
