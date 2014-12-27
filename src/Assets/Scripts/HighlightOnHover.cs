using UnityEngine;
using System.Collections;

public class HighlightOnHover : MonoBehaviour {

	public Color startcolor;
	public Color hovercolor;
	public Color selectedcolor;
	public bool selected = false;
	private HighlightOnHover[] allTracksProps;
	
	void Start()
	{
		allTracksProps = gameObject.transform.parent.gameObject.GetComponentsInChildren<HighlightOnHover>();
		//Debug.Log(allTracksProps[0]);
		startcolor = renderer.material.color;
	}

	void OnMouseEnter()
	{
		if(!selected){
			renderer.material.color = hovercolor;
			//GetComponentInParent<AudioSource>().Play();
		}
	}

	void OnMouseDown()
	{
		if(!selected){
			foreach(HighlightOnHover trackProps in allTracksProps){
				trackProps.Unselect();
			}
			Select();
		} else {
			Unselect();
		}
	}

	void OnMouseExit()
	{
		if(!selected){
			renderer.material.color = startcolor;
		}
		
	}

	void Select(){
		selected = true;
		renderer.material.color = selectedcolor;
	}

	void Unselect(){
		selected = false;
		renderer.material.color = startcolor;
	}

}
