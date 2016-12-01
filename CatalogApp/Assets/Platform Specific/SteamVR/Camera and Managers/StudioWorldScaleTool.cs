using UnityEngine;
using System.Collections;

public class StudioWorldScaleTool : MonoBehaviour {
	public GameObject studioWorld;
	public Transform HMD;
	public float scaleFactor;
	float resetScaleTimer;
	public float resetScaleLength = 2;
	float distanceBetweenHands;
	float distanceBetweenHandsPrev;
	float scalingStartDistance;
	bool cursorGripPressed, offhandGripPressed, scaling;
	void OnEnable () {
		scaling = false;
		cursorGripPressed = false;
		offhandGripPressed = false;
		SteamVR_InputManager.OnCursorHandGripPressDown += CursorGripPressDown;
		SteamVR_InputManager.OnCursorHandGripPress += CursorGripPress;
		SteamVR_InputManager.OnCursorHandGripPressDown += CursorGripPressUp;
		SteamVR_InputManager.OnOffHandGripPressDown += OffhandGripPressDown;
		SteamVR_InputManager.OnOffHandGripPressUp += OffhandGripPressUp;
	}

	void CursorGripPressDown(){
		cursorGripPressed = true;
		scaling = false;
	}

	void CursorGripPressUp(){
		cursorGripPressed = false;
	}
	void CursorGripPress(){
		if(offhandGripPressed){
			distanceBetweenHands = (SteamVR_InputManager.offHand.transform.position-SteamVR_InputManager.cursorHand.transform.position).magnitude;
			if(!scaling){
				scaling = true;
				distanceBetweenHandsPrev = distanceBetweenHands;
				scalingStartDistance = distanceBetweenHands;
				print(scalingStartDistance);
			}
			else{
				float scaleBy = 1 + ((distanceBetweenHands-distanceBetweenHandsPrev)/scalingStartDistance)*scaleFactor;
				studioWorld.transform.localScale *=  scaleBy;
				Vector3 moveTo = (new Vector3((studioWorld.transform.position.x - HMD.position.x)*scaleBy, 0, (studioWorld.transform.position.z - HMD.position.z)*scaleBy) + new Vector3(HMD.position.x, 0, HMD.position.z));
				studioWorld.transform.position = moveTo;
			}
			distanceBetweenHandsPrev=distanceBetweenHands;
		}
		else{
			resetScaleTimer-= Time.deltaTime;
			if(resetScaleTimer<0){
				
			}
		}	
	}

	void OffhandGripPressDown(){
		offhandGripPressed = true;
		print("things");
	}

	void OffhandGripPressUp(){
		offhandGripPressed = false;
	}
	void resetTimer(){
		resetScaleTimer = resetScaleLength;
	}
}
