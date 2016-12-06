using UnityEngine;
using System.Collections;

public class BoxHighlighter : MonoBehaviour, Highlighter {
	GameObject currentObject;
	GameObject cornerParent;
	public GameObject cornerPrefab;
	public GameObject [] corners;
	Vector3 [] cornerPos = new Vector3[8];
	// Use this for initialization
	void Start () {
		cornerParent = new GameObject();
		cornerParent.transform.parent = this.transform;
		for(int i=0; i<8; i++){
			GameObject go = Instantiate(cornerPrefab);
			cornerPos[i] = Vector3.zero;
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
	}
	
	// Update is called once per frame
	void Update () {
		if(currentObject){
			if(currentObject.transform.hasChanged){
				setCornerPos(currentObject.GetComponent<Collider>().bounds);
			}
			for(int i=0; i<8; i++){
				corners[i].transform.position = Vector3.Slerp(corners[i].transform.position, cornerPos[i], 0.5f);
			}	
		}
	}

	public void Highlight(GameObject target){	
		if(target == null){
			return;	
		}
		currentObject = target;
		if(currentObject.GetComponent<Collider>()){
			cornerParent.transform.position = target.transform.position;
			Bounds b = target.GetComponent<Collider>().bounds;
			setCornerPos(currentObject.GetComponent<Collider>().bounds);
			for(int i=0; i<8; i++){
				corners[i].SetActive(true);
			}
		}
	}

	void setCornerPos(Bounds b){
		cornerPos[0] = b.center + (new Vector3 (b.extents.x, b.extents.y, b.extents.z));
		cornerPos[1] = b.center + (new Vector3 (b.extents.x * -1, b.extents.y, b.extents.z));
		cornerPos[2] = b.center + (new Vector3 (b.extents.x * -1, b.extents.y * -1, b.extents.z));
		cornerPos[3] = b.center + (new Vector3 (b.extents.x * -1, b.extents.y * -1, b.extents.z * -1));
		cornerPos[4] = b.center + (new Vector3 (b.extents.x, b.extents.y * -1, b.extents.z * -1));
		cornerPos[5] = b.center + (new Vector3 (b.extents.x, b.extents.y, b.extents.z * -1));
		cornerPos[6] = b.center + (new Vector3 (b.extents.x, b.extents.y * -1, b.extents.z));
		cornerPos[7] = b.center + (new Vector3 (b.extents.x * -1, b.extents.y, b.extents.z * -1));
	}

	public void UnHighlight(){

	}
}
