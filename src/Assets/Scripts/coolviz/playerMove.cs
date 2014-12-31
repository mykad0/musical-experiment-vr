using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour {
	public	float				speed;					// The speed of the controller
	public	Vector3				gravityCte;				// The gravity represented by a vector
	public	float				jumpCte;				// Constant of jump
	public	float				rotCte;					// Constant of rotation
	
	private	CharacterController	_myController;
	private	Vector3				_newPos;
	private	Transform			_camTransform = null;
	private	Vector3				_newRotCam;
	private	Vector3				_newRotPlayer;

	void Start () {
		Transform				[]_tmp;
		_myController = this.GetComponent<CharacterController> ();
		_tmp = GetComponentsInChildren<Transform> ();
		for (int i = 0; i < _tmp.Length; i++)
			if (_tmp[i].tag == "MainCamera")
				_camTransform = _tmp[i];
	}
	
	void Update () {
		if (Input.GetButtonDown("Sprint"))
			speed *= 2.0f;
		else if (Input.GetButtonUp("Sprint"))
			speed /= 2.0f;
		if (_myController.isGrounded)
		{
			_newPos = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
			_newPos = transform.TransformDirection(_newPos);
			_newPos *= speed;
			if (Input.GetButtonDown("Jump"))
				_newPos += jumpCte * (-gravityCte);
		}
		_newPos += gravityCte * Time.deltaTime;
		_myController.Move(_newPos * Time.deltaTime);
		_newRotPlayer = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + (Input.GetAxis("Mouse X") * rotCte), transform.eulerAngles.z);
		_newRotCam = new Vector3(_camTransform.localEulerAngles.x + (-Input.GetAxis("Mouse Y") * rotCte), 0.0f, 0.0f);
		transform.eulerAngles = Vector3.Lerp (transform.eulerAngles, _newRotPlayer, Time.smoothDeltaTime * 4.0f);
		_camTransform.localEulerAngles = Vector3.Lerp (_camTransform.localEulerAngles, _newRotCam, Time.smoothDeltaTime * 4.0f);
	}
}
