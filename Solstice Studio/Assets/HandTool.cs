using UnityEngine;
using System.Collections;

public class HandTool : MonoBehaviour {

	GameObject currentObject;
	public GameObject studioWorld;
	// Use this for initialization
	TrackedControllerTarget targetProvider;
	GameObject parentObj;
	void OnEnable () {
		SteamVR_InputManager.OnCursorHandTriggerPressDown += CursorTriggerPressDown;
		SteamVR_InputManager.OnCursorHandTriggerPressUp += CursorTriggerPressUp;
		targetProvider = FindObjectOfType<TrackedControllerTarget>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CursorTriggerPressDown(){
		//Parent object to controller
		if(targetProvider.targetObj){
			targetProvider.targetObj.transform.parent = targetProvider.transform;
			currentObject = targetProvider.targetObj;
		}
	}

	void CursorTriggerPressUp(){
		//Unparent object from controller
		if(currentObject){
			targetProvider.targetObj.transform.parent = studioWorld.transform;
			currentObject=null;
		}
	}
}
