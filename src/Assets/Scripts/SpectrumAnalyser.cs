using UnityEngine;
using System.Collections;

public class SpectrumAnalyser : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float[] spectrum = AudioListener.GetSpectrumData(1024, 0, FFTWindow.Hamming);
	 
		GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cubes");

		for(int i=1;i<cubes.Length;i++)
		{
			if(i < 16)
			{
				cubes[i].transform.localScale =  new Vector3 (0.5f, cap(100*(spectrum[i])), 0.5f); 
				cubes[i].transform.position =  new Vector3 (cubes[i].transform.position.x,  cubes[i].transform.localScale.y / 2, cubes[i].transform.position.z); 
			}
			else if(i < 32)
			{
				cubes[i].transform.localScale =  new Vector3 (0.5f, cap(100*(spectrum[i] + spectrum[i+1] + spectrum[i+2])), 0.5f); 
				cubes[i].transform.position =  new Vector3 (cubes[i].transform.position.x,  cubes[i].transform.localScale.y / 2, cubes[i].transform.position.z); 
			}
			else if(i < 48)
			{
				cubes[i].transform.localScale =  new Vector3 (0.5f, cap(100*(spectrum[i+1] + spectrum[i+2] + spectrum[i+3] + spectrum[i+4] + spectrum[i+5])), 0.5f); 
				cubes[i].transform.position =  new Vector3 (cubes[i].transform.position.x,  cubes[i].transform.localScale.y / 2, cubes[i].transform.position.z); 
			}
			else
			{
				cubes[i].transform.localScale =  new Vector3 (0.5f, cap(100*(spectrum[i+1] + spectrum[i+2] + spectrum[i+3] + spectrum[i+4] + spectrum[i+5])), 0.5f); 
				cubes[i].transform.position =  new Vector3 (cubes[i].transform.position.x,  cubes[i].transform.localScale.y / 2, cubes[i].transform.position.z); 
			}
		}
	}

	float cap( float v) {
		if(v < 0.1f) { v=0.1f; return v;}
		else if (v > 20f) { v = 20f; return v;}
		else { return v; }
	}

	 
}
