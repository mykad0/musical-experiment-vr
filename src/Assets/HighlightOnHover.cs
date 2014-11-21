using UnityEngine;
using System.Collections;

public class HighlightOnHover : MonoBehaviour {

	public Color startcolor;

	void OnInitialize()
	{
		renderer.material.color = startcolor;
	}
	void OnMouseEnter()
	{
		print ("hover");
		startcolor = renderer.material.color;
		renderer.material.color = Color.yellow;
	}
	void OnMouseExit()
	{
		renderer.material.color = startcolor;
	}

}
