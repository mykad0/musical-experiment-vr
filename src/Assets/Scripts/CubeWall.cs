using UnityEngine;
using System.Collections;

public class CubeWall : MonoBehaviour {

	public GameObject cube;
	public int numberOfObjects = 64;
	public float radius = 12f;

	// Use this for initialization
	void Start() {

		int nextNameNumber = 0;
	    for (int i = 0; i < numberOfObjects; i++) {
	        float angle = i * Mathf.PI * 2 / numberOfObjects;
	        Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
	        GameObject cubewow = (GameObject) Instantiate(cube, pos, Quaternion.identity);
	        cubewow.name = "brick"+nextNameNumber;
	        cubewow.transform.parent = gameObject.transform;
	        nextNameNumber++;
	    }
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
