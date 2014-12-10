using UnityEngine;
using System;

public class KinectHandCursor : MonoBehaviour 
{
	public bool isRightHanded = true;
	public float smoothFactor = 5f;
	public GameObject Cursor;
	
	private float distanceToCamera;
	private KinectWrapper.NuiSkeletonPositionIndex handTracked;
	
	
	void Start(){
		if (isRightHanded){
			handTracked = KinectWrapper.NuiSkeletonPositionIndex.HandRight;
		} else {
			handTracked = KinectWrapper.NuiSkeletonPositionIndex.HandLeft;
		}
		if(Cursor){
			distanceToCamera = (Cursor.transform.position - Camera.main.transform.position).magnitude;
		}
	}

	void Update(){
		KinectManager manager = KinectManager.Instance;

		if(manager && manager.IsInitialized())
		{
			int iJointIndex = (int)handTracked;

			if(manager.IsUserDetected()){
				uint userId = manager.GetPlayer1ID();
				
				if(manager.IsJointTracked(userId, iJointIndex))
				{
					Vector3 posJoint = manager.GetRawSkeletonJointPos(userId, iJointIndex);

					if(posJoint != Vector3.zero)
					{
						// 3d position to depth
						Vector2 posDepth = manager.GetDepthMapPosForJointPos(posJoint);
						
						// depth pos to color pos
						Vector2 posColor = manager.GetColorMapPosForDepthPos(posDepth);
						
						float scaleX = (float)posColor.x / KinectWrapper.Constants.ColorImageWidth;
						float scaleY = 1.0f - (float)posColor.y / KinectWrapper.Constants.ColorImageHeight;
					
						if(Cursor){
							Vector3 vPosCursor = Camera.main.ViewportToWorldPoint(new Vector3(scaleX, scaleY, distanceToCamera));
							Cursor.transform.position = Vector3.Lerp(Cursor.transform.position, vPosCursor, smoothFactor * Time.deltaTime);
						}

					}
				}
			}
		}

	}
}