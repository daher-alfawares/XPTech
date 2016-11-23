using UnityEngine;
using UnityEditor;
using System.Collections;

 
public class CenterObject : MonoBehaviour {
    
    [MenuItem("My Tools/Fix Object Center")]
    
    static void FixObjectCenter() {
        Transform [] trans = Selection.GetTransforms(SelectionMode.TopLevel);
        Vector3 center = FindThePivot(trans);
        GameObject newParent = new GameObject("ObjCenter");
        newParent.transform.position = center;
        Transform originalParent = trans[0].parent;
        foreach (var t in trans)
            t.parent = newParent.transform;
        newParent.transform.parent = originalParent;
        newParent.transform.localPosition = Vector3.zero; 


    }
    static Vector3 FindThePivot(Transform[] trans) {
        if (trans == null || trans.Length == 0)
            return Vector3.zero;
        if (trans.Length == 1)
            return trans[0].position;
        
        float minX = Mathf.Infinity;
        float minY = Mathf.Infinity;
        float minZ = Mathf.Infinity;
        
        float maxX = -Mathf.Infinity;
        float maxY = -Mathf.Infinity;
        float maxZ = -Mathf.Infinity;
        
        foreach (Transform tr in trans) {
            if (tr.position.x < minX)
                minX = tr.position.x;
            if (tr.position.y < minY)
                minY = tr.position.y;
            if (tr.position.z < minZ)
                minZ = tr.position.z;
            
            if (tr.position.x > maxX)
                maxX = tr.position.x;
            if (tr.position.y > maxY)
                maxY = tr.position.y;
            if (tr.position.z > maxZ)
                maxZ = tr.position.z;
        }
        
        return new Vector3((minX+maxX)/2.0f,0,(minZ+maxZ)/2.0f); 
    }
}