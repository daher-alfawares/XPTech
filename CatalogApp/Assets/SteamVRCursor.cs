using UnityEngine;
using System.Collections;

public class SteamVRCursor : MonoBehaviour {

	public GameObject cursorPoint;
	public GameObject hoverObj;
	public float maxDist = 10.0f;
	public TextMesh ObjName;
	LineRenderer laserLine;
	bool useLaser = true;
	// Use this for initialization
	void Start () {
		laserLine = this.GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(useLaser){
			laserUpdate();
		}

	}

	void laserUpdate() {
		RaycastHit cursorLoc;
		if(Physics.Raycast(this.gameObject.transform.position, this.gameObject.transform.forward, out cursorLoc, maxDist)){
			if(cursorLoc.collider.gameObject != hoverObj){
				hoverObj = cursorLoc.collider.gameObject;
				ObjName.text = hoverObj.name;
				highlightObj();
			}
			
			cursorPoint.transform.position = cursorLoc.point;
		}
		else{
			ObjName.text = "";
			hoverObj = null;
			cursorPoint.transform.localPosition = new Vector3(0,0,maxDist);
		}
		laserLine.SetPosition(1, cursorPoint.transform.localPosition);
	}

	void highlightObj(){
		
		
	}
}
