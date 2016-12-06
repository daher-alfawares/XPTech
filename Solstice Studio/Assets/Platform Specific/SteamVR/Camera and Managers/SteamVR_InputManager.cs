using UnityEngine;
using System.Collections;

public class SteamVR_InputManager : MonoBehaviour {
	public enum CursorLocation {Left, Right};
	public GameObject targetProvider;
	public CursorLocation cursorLocation;
	public SteamVR_ControllerManager steamVRManager;
	//public static GameObject leftController, rightController;
	GameObject cursorInstance;
	public static GameObject cursorHand, offHand;
	public delegate void CursorControllerUpdate();
	public static event CursorControllerUpdate OnCursorHandGripPressDown,
											OnCursorHandGripPressUp,
											OnCursorHandGripPress,
											OnCursorHandTriggerPressDown,
											OnCursorHandTriggerPressUp;
	
	public delegate void OffhandControllerUpdate();
	public static event OffhandControllerUpdate OnOffHandGripPressDown,
											OnOffHandGripPressUp,
											OnOffHanddGripPress,
											OnOffHandTriggerPressDown,
											OnOffHandTriggerPressUp;
	
	// Use this for initialization
	void Start () {
		cursorHand = steamVRManager.right;
		offHand = steamVRManager.left;
		AssignCursorLocation();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		var cursorHandDevice = SteamVR_Controller.Input((int)cursorHand.GetComponent<SteamVR_TrackedObject>().index);
		//cursor hand inputs
		if (cursorHandDevice.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
		{
			if(OnCursorHandTriggerPressDown != null)
				OnCursorHandTriggerPressDown();
		}
		if (cursorHandDevice.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
		{
			if(OnCursorHandTriggerPressUp != null)
				OnCursorHandTriggerPressUp();
		}
		if (cursorHandDevice.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
		{
			if(OnCursorHandGripPressDown != null)
				OnCursorHandGripPressDown();
		}
		if (cursorHandDevice.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
		{
			if(OnCursorHandGripPressUp != null)
				OnCursorHandGripPressUp();
		}
		if (cursorHandDevice.GetPress(SteamVR_Controller.ButtonMask.Grip))
		{
			if(OnCursorHandGripPress != null)
				OnCursorHandGripPress();
		}
		
		//offhand inputs 
		var offHandDevice = SteamVR_Controller.Input((int)offHand.GetComponent<SteamVR_TrackedObject>().index);
		if (offHandDevice.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
		{
			if(OnOffHandGripPressDown != null)
				OnOffHandGripPressDown();
		}
		if (offHandDevice.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
		{
			if(OnOffHandGripPressUp != null)
				OnOffHandGripPressUp();
		}
	}

	void AssignCursorLocation(){
		switch (cursorLocation){
			case CursorLocation.Left:
				targetProvider.transform.parent = steamVRManager.left.transform;
				cursorHand = steamVRManager.left;
				offHand = steamVRManager.right;
				targetProvider.transform.localPosition = Vector3.zero;
			break;
			case CursorLocation.Right:
				targetProvider.transform.parent = steamVRManager.right.transform;
				cursorHand = steamVRManager.right;
				offHand = steamVRManager.left;
				targetProvider.transform.localPosition = Vector3.zero;
			break;
		}

	}

	void Click(){

	}
}
