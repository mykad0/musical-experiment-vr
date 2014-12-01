using UnityEngine;
using System.Collections;

public class HighlightOnHover : MonoBehaviour {

	public Color startcolor;
	public bool Lock = false;
	
	void OnInitialize()
	{
		renderer.material.color = startcolor;
	}

	void OnMouseEnter()
	{
		startcolor = renderer.material.color;
		renderer.material.color = Color.yellow;
	}

	void OnMouseDown()
	{
		renderer.material.color = Color.red;
		Lock = !Lock;
		 
	}

	void OnMouseExit()
	{
		renderer.material.color = startcolor;
	}

}
