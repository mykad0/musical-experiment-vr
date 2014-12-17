using UnityEngine;
using System.Collections;

public class GenerateNotes : MonoBehaviour {

	public int nbNotes;
	public float y;
	public float radius;
	private int noteNumber = 1;
	private GameObject note;
	private float coefMult = 11;
	private float offset = 0.15f;

	// Use this for initialization
	void Start () {
		//float stepAngle = 360/nbNotes;
		//float angle = 0;
		radius *= coefMult;
		radius -= offset;
		note = GameObject.Find("Note#0");
		for(int i=0;i<nbNotes;i++){
			//float x = (radius*Mathf.Cos(angle));
			//float z = (radius*Mathf.Sin(angle));
			float angle = i * Mathf.PI * 2 / nbNotes;
	        Vector3 pos = new Vector3(Mathf.Cos(angle) * radius, y, Mathf.Sin(angle) * radius);
	       	//GameObject notetmp = (GameObject) Instantiate(note, new Vector3(x, y, z), Quaternion.identity);
			GameObject notetmp = (GameObject) Instantiate(note, pos, Quaternion.identity);
			notetmp.name = "Note#"+noteNumber;
			notetmp.transform.parent = gameObject.transform;
			//angle = angle + stepAngle;
			noteNumber++;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
