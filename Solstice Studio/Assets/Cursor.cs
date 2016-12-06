using UnityEngine;
using System.Collections;

public class Cursor : MonoBehaviour
{
    [Tooltip("Maximum gaze distance for calculating a hit.")]
    public float MaxGazeDistance = 5.0f;

    private Gaze gaze;
    private void Awake()
    {
        gaze = GetComponent<Gaze>();
    }

    private void LateUpdate()
    {
        Vector3 Position = gaze.Position;
        Vector3 Normal = gaze.Normal;
        GameObject Object = gameObject;

        if(gaze.Hit) {
            Object = gaze.HitInfo.collider.gameObject;
        }

        CursorProvider Provider = Object.GetComponentInParent<CursorProvider>();
        if (Provider)
        {
            //Provider.ShowCursor(Position, Normal);
        }
    }
}