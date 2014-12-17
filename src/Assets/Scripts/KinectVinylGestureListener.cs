using UnityEngine;
using System.Collections;
using System;

public class KinectVinylGestureListener : MonoBehaviour, KinectGestures.GestureListenerInterface {

	public GUIText GestureInfo;
	
	private bool swipeUp;
	private bool swipeDown;

	public bool IsSwipeUp()
	{
		if(swipeUp)
		{
			swipeUp = false;
			return true;
		}
		
		return false;
	}
	
	public bool IsSwipeDown()
	{
		if(swipeDown)
		{
			swipeDown = false;
			return true;
		}
		
		return false;
	}

	// Invoked when a new user is detected and tracking starts
	// Here you can start gesture detection with KinectManager.DetectGesture()
	public void UserDetected(uint userId, int userIndex){
				// detect these user specific gestures
				KinectManager manager = KinectManager.Instance;

				manager.DetectGesture(userId, KinectGestures.Gestures.SwipeUp);
				manager.DetectGesture(userId, KinectGestures.Gestures.SwipeDown);
		
				if (GestureInfo != null) {
						GestureInfo.guiText.text = "Swipe up or down to switch mode";
				}
		}
	
	// Invoked when a user is lost
	// Gestures for this user are cleared automatically, but you can free the used resources
	public void UserLost(uint userId, int userIndex){
			if(GestureInfo != null)
			{
				GestureInfo.guiText.text = string.Empty;
			}
		}
	
	// Invoked when a gesture is in progress 
	public void GestureInProgress(uint userId, int userIndex, KinectGestures.Gestures gesture, float progress, 
	                       KinectWrapper.SkeletonJoint joint, Vector3 screenPos){
		}
	
	// Invoked if a gesture is completed.
	// Returns true, if the gesture detection must be restarted, false otherwise
	public bool GestureCompleted(uint userId, int userIndex, KinectGestures.Gestures gesture,
	                      KinectWrapper.SkeletonJoint joint, Vector3 screenPos){
		
		string sGestureText = gesture + " detected";
		if(GestureInfo != null)
		{
			GestureInfo.guiText.text = sGestureText;
		}

		if(gesture == KinectGestures.Gestures.SwipeUp)
			swipeUp = true;
		else if(gesture == KinectGestures.Gestures.SwipeDown)
			swipeDown = true;
	
		return true;
	}
	
	// Invoked if a gesture is cancelled.
	// Returns true, if the gesture detection must be retarted, false otherwise
	public bool GestureCancelled(uint userId, int userIndex, KinectGestures.Gestures gesture, 
	                      KinectWrapper.SkeletonJoint joint){
			return true;
		}
}
