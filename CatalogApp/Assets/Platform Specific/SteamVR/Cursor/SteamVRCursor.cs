using UnityEngine;
using System.Collections;

public class SteamVRCursor : MonoBehaviour {

	public GameObject cursorPoint;
	public GameObject targetObj;
	public float maxLaserDistance;
	public float directInteractionRadius;
	public TextMesh ObjName;
	LineRenderer laserLine;
	public bool useLaser;
	// Use this for initialization
	void Start () {
		laserLine = this.GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(useLaser){
			laserUpdate();
		}
		else{
			trackedControllerUpdate();
		}
	}

	void laserUpdate() {
		RaycastHit cursorLoc;
		if(Physics.Raycast(this.gameObject.transform.position, this.gameObject.transform.forward, out cursorLoc, maxLaserDistance)){
			changeTarget(cursorLoc.transform.gameObject);
			cursorPoint.transform.position = cursorLoc.point;
		}
		else{
			changeTarget(null);
			cursorPoint.transform.localPosition = new Vector3(0,0,maxLaserDistance);
		}
		laserLine.SetPosition(1, cursorPoint.transform.localPosition);
	}

	void trackedControllerUpdate(){
		 Collider[] hitColliders = Physics.OverlapSphere(transform.position, directInteractionRadius);
		 if(hitColliders.Length>0){
			 changeTarget(hitColliders[0].transform.gameObject);
		 }
		 else{
			 changeTarget(null);
		 }
	}

	void changeTarget(GameObject hitObject){
		if(hitObject != targetObj){
			if(hitObject){
				targetObj = hitObject;
				ObjName.text = targetObj.name;
			}
			else{
				ObjName.text = "";
				targetObj = null;
			}
		}
	}
	void toggleCursorType(){
		if(useLaser){
			cursorPoint.transform.localPosition = Vector3.zero;
			laserLine.enabled = false;
		}
		else{
			laserLine.enabled = false;
		}
		useLaser=!useLaser;
	}
	void highlightObj(){
		
		
	}
}
