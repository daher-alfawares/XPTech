using UnityEngine;
using System.Collections;

public class TrackedControllerTarget : MonoBehaviour, TargetProvider {

	public bool Hit { get;  set; }

    /// <summary>
    /// HitInfo property gives access
    /// to RaycastHit public members.
    /// </summary>
    public RaycastHit HitInfo { get;  set; }

    /// <summary>
    /// Position of the user's gaze.
    /// </summary>
    public Vector3 Position { get;  set; }

    /// <summary>
    /// RaycastHit Normal direction.
    /// </summary>
    public Vector3 Normal { get;  set; }
	public GameObject targetObj { get;  set; }
	public float maxLaserDistance;
	public float directInteractionRadius;
	public TextMesh ObjName;
	public GameObject hitLocation;
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
		if(Physics.Raycast(this.transform.position, this.transform.forward, out cursorLoc, maxLaserDistance)){
			Hit = true;
			
			Position = cursorLoc.point;
			Normal = cursorLoc.normal;

			changeTarget(cursorLoc.transform.gameObject);
			hitLocation.transform.position = Position;
			laserLine.SetPosition(1, hitLocation.transform.localPosition);
		}
		else{
			Hit = false;
			Position = this.transform.position + this.transform.forward * maxLaserDistance;
			Normal = this.transform.forward;
			changeTarget(null);
			laserLine.SetPosition(1, Vector3.forward*maxLaserDistance
			);
		}
		HitInfo=cursorLoc;
		
	}

	void trackedControllerUpdate(){
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, directInteractionRadius);
		if(hitColliders.Length>0){
			Hit=true;
			RaycastHit cursorLoc;
			changeTarget(hitColliders[0].transform.gameObject);
			Physics.Raycast(this.gameObject.transform.position, this.gameObject.transform.position-hitColliders[0].transform.position, out cursorLoc, directInteractionRadius);
			HitInfo = cursorLoc;
			Normal = cursorLoc.normal;
			Position = cursorLoc.point;
		}
		else{
			Hit = false;
			Position = this.transform.position;
			Normal = this.transform.forward;
			changeTarget(null);
		}
}

	void changeTarget(GameObject hitObject){
		if(hitObject != targetObj){
			if(hitObject){
				targetObj = hitObject;
				Bounds b = targetObj.GetComponent<Collider>().bounds;//debug
				ObjName.text = b.extents.ToString();//debug
				highlightObj(hitObject);
			}
			else{
				ObjName.text = "";
				targetObj = null;
			}
		}
	}
	void toggleCursorType(){
		if(useLaser){
			laserLine.enabled = false;
		}
		else{
			laserLine.enabled = false;
		}
		useLaser=!useLaser;
	}
	void highlightObj(GameObject Object){
		Highlighter highlight = (Highlighter) Object.GetComponentInParent(typeof(Highlighter));
			if (highlight is Highlighter){
				highlight.Highlight(Object);
			}
	}
}
