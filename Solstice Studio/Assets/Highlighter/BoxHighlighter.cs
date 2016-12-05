using UnityEngine;
using System.Collections;

public class BoxHighlighter : MonoBehaviour, Highlighter {
	GameObject currentObject;
	GameObject cornerParent;
	public GameObject cornerPrefab;
	public GameObject [] corners;
	public GameObject Test;
	// Use this for initialization
	void Start () {
		cornerParent = new GameObject();
		for(int i=0; i<8; i++){
			GameObject go = Instantiate(cornerPrefab);
			corners[i]= go;
			go.transform.parent = cornerParent.transform;
			go.SetActive(false);
		}
		corners[0].transform.rotation = Quaternion.Euler(0,180,-90);
		corners[1].transform.rotation = Quaternion.Euler(180,0,0);
		corners[2].transform.rotation = Quaternion.Euler(0,90,0);
		corners[3].transform.rotation = Quaternion.Euler(0,0,0);
		corners[4].transform.rotation = Quaternion.Euler(0,-90,0);
		corners[5].transform.rotation = Quaternion.Euler(90,0,90);
		corners[6].transform.rotation = Quaternion.Euler(0,180,0);
		corners[7].transform.rotation = Quaternion.Euler(0,0,-90);
		Highlight(Test);
	}
	
	// Update is called once per frame
	void Update () {
		if(currentObject){
			cornerParent.transform.position = currentObject.transform.position;
		//cornerParent.transform.rotation = currentObject.transform.rotation;
		}
	}

	public void Highlight(GameObject target){
		cornerParent.transform.position = target.transform.position;
		//cornerParent.transform.rotation = target.transform.rotation;
		currentObject = target;
		Bounds b = target.GetComponent<Collider>().bounds;
		corners[0].transform.position = b.center + (new Vector3 (b.extents.x, b.extents.y, b.extents.z));
		corners[1].transform.position = b.center + (new Vector3 (b.extents.x * -1, b.extents.y, b.extents.z));
		corners[2].transform.position = b.center + (new Vector3 (b.extents.x * -1, b.extents.y * -1, b.extents.z));
		corners[3].transform.position = b.center + (new Vector3 (b.extents.x * -1, b.extents.y * -1, b.extents.z * -1));
		corners[4].transform.position = b.center + (new Vector3 (b.extents.x, b.extents.y * -1, b.extents.z * -1));
		corners[5].transform.position = b.center + (new Vector3 (b.extents.x, b.extents.y, b.extents.z * -1));
		corners[6].transform.position = b.center + (new Vector3 (b.extents.x, b.extents.y * -1, b.extents.z));
		corners[7].transform.position = b.center + (new Vector3 (b.extents.x * -1, b.extents.y, b.extents.z * -1));

		for(int i=0; i<8; i++){
			corners[i].SetActive(true);
		}
	}
}
