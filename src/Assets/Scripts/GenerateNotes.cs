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

			float angle = i * Mathf.PI * 2 / nbNotes;
	        Vector3 pos = new Vector3(Mathf.Cos(angle) * radius, y, Mathf.Sin(angle) * radius);	       	 
			
			/* Instantiation */
			GameObject notetmp = (GameObject) Instantiate(note, pos, Quaternion.identity);
			notetmp.name = "Note#"+noteNumber+transform.collider.name;
			notetmp.transform.parent = gameObject.transform;
			noteNumber++;
			//angle = angle + stepAngle;

			/* Interaction */
			notetmp.tag = "Note";
			AudioSource audioSource = notetmp.AddComponent<AudioSource>();
			audioSource.mute = true;

			if( transform.collider.name == "Track#1") {
				audioSource.clip = Resources.Load<AudioClip>("VIHat") as AudioClip;
			}	
			else if( transform.collider.name == "Track#2") {
				audioSource.clip = Resources.Load<AudioClip>("VISnare") as AudioClip;
			}
			else if( transform.collider.name == "Track#3") {
				audioSource.clip = Resources.Load<AudioClip>("VIclap") as AudioClip;
			}
			else if( transform.collider.name == "Track#4") {
				audioSource.clip = Resources.Load<AudioClip>("VIKick") as AudioClip;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
