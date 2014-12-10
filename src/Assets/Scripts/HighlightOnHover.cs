using UnityEngine;
using System.Collections;

public class HighlightOnHover : MonoBehaviour {

	public Color startcolor;
	public Color hovercolor;
	public Color selectedcolor;
	public bool selected = false;
	
	void OnInitialize()
	{
		renderer.material.color = startcolor;
	}

	void OnMouseEnter()
	{
		if(!selected){
			startcolor = renderer.material.color;
			renderer.material.color = hovercolor;
		}
	}

	void OnMouseDown()
	{
		if(!selected){
			renderer.material.color = selectedcolor;
		} else {
			renderer.material.color = startcolor;
		}
		
		selected = !selected;
		 
	}

	void OnMouseExit()
	{
		if(!selected){
			renderer.material.color = startcolor;
		}
		
	}

}
