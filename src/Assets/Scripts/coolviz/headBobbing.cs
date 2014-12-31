using UnityEngine;
using System.Collections;

public class headBobbing : MonoBehaviour {
	private	float		_timer = 0.0f;
	private	Vector3		_posSave;
	private	Transform	_myTransform;
	public	float		bobbingSpeed;
	public	float		bobbingAmount;
	
	void Start () {
		_myTransform = this.GetComponent<Transform> ();
		_posSave = _myTransform.localPosition;
	}
	
	void Update () {
		if (Input.GetButtonDown("Sprint"))
		{
			bobbingSpeed *= 1.5f;
			bobbingAmount *= 2.0f;
		}
		else if (Input.GetButtonUp("Sprint"))
		{
			bobbingSpeed /= 1.5f;
			bobbingAmount /= 2.0f;			
		}
		if (Input.GetAxis("Horizontal") == 0.0f && Input.GetAxis("Vertical") == 0.0f)
			_timer = 0.0f;
		else
			_timer += Time.deltaTime;
		_myTransform.localPosition = Vector3.Lerp(_myTransform.localPosition, new Vector3(_posSave.x, _posSave.y + Mathf.Sin(((_timer) * 180.0f / Mathf.PI) * bobbingSpeed) * bobbingAmount, _posSave.z), Time.smoothDeltaTime * 4.0f);
	}
}
