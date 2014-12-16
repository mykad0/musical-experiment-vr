using UnityEngine;
using System.Collections;

public class SpectrumAnalyser : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float[] spectrum = AudioListener.GetSpectrumData(1024, 0, FFTWindow.Hamming);
		float c0 = spectrum[3] ;
		float c1 = spectrum[11] + spectrum[12] + spectrum[13];
		float c2 = spectrum[22] + spectrum[23] + spectrum[24];
		float c3 = spectrum[44] + spectrum[45] + spectrum[46] + spectrum[47]  + spectrum[48] + spectrum[49];


	 

		GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cubes");

		for( int i=1;i<cubes.Length+1; i=i+3)
		{
			 
		cubes[i].transform.localScale =  new Vector3 (0.5f, 100*(spectrum[i]+spectrum[i+1]+spectrum[i+2]), 0.5f); 
			cubes[i].transform.position =  new Vector3 (cubes[i].transform.position.x, 50*(spectrum[i]+spectrum[i+1]+spectrum[i+2]), cubes[i].transform.position.z); 
				 
		}
	}
}
