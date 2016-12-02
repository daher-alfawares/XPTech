using UnityEngine;
using System.Collections;

public class CursorProvider : MonoBehaviour {

    [Tooltip("Set the cursor object set this on the parent of an object group.")]
    public GameObject HoverCursor;

    public void ShowCursor( Vector3 Position, Vector3 Normal)
    {
        HoverCursor.SetActive(true);
        HoverCursor.transform.position = Position;
        HoverCursor.transform.up = Normal;
    }
}
