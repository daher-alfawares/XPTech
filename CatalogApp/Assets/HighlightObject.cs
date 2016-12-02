using UnityEngine;
using System.Collections;

public class HighlightObject : MonoBehaviour {
	public GameObject [] corners;
	// Use this for initialization
	void Start () {
		Bounds b = this.GetComponent<Collider>().bounds;
		corners[0].transform.position = b.center + (new Vector3 (b.extents.x, b.extents.y, b.extents.z));
		corners[1].transform.position= b.center + (new Vector3 (b.extents.x * -1, b.extents.y, b.extents.z));
		corners[2].transform.position= b.center + (new Vector3 (b.extents.x * -1, b.extents.y * -1, b.extents.z));
		corners[3].transform.position= b.center + (new Vector3 (b.extents.x * -1, b.extents.y * -1, b.extents.z * -1));
		corners[4].transform.position= b.center + (new Vector3 (b.extents.x, b.extents.y * -1, b.extents.z * -1));
		corners[5].transform.position= b.center + (new Vector3 (b.extents.x, b.extents.y, b.extents.z * -1));
		corners[6].transform.position= b.center + (new Vector3 (b.extents.x, b.extents.y * -1, b.extents.z));
		corners[7].transform.position= b.center + (new Vector3 (b.extents.x * -1, b.extents.y, b.extents.z * -1));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
