using UnityEngine;
using System.Collections;

public class HighlightObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Bounds b = this.GetComponent<Collider>().bounds;
		Vector3 [] corners = new Vector3[8];
		corners[0]= transform.worldToLocalMatrix*(new Vector3 (b.extents.x, b.extents.y, b.extents.z));
		corners[0]= b.center + (new Vector3 (b.extents.x * -1, b.extents.y, b.extents.z));
		corners[0]= b.center + (new Vector3 (b.extents.x * -1, b.extents.y * -1, b.extents.z));
		corners[0]= b.center + (new Vector3 (b.extents.x * -1, b.extents.y * -1, b.extents.z * -1));
		corners[0]= b.center + (new Vector3 (b.extents.x, b.extents.y * -1, b.extents.z * -1));
		corners[0]= b.center + (new Vector3 (b.extents.x, b.extents.y, b.extents.z * -1));
		corners[0]= b.center + (new Vector3 (b.extents.x, b.extents.y * -1, b.extents.z));
		corners[0]= b.center + (new Vector3 (b.extents.x * -1, b.extents.y, b.extents.z * -1));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
