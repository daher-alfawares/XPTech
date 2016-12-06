using UnityEngine;
using System.Collections;

public interface TargetProvider {

	bool Hit { get; set; }

    /// <summary>
    /// HitInfo property gives access
    /// to RaycastHit public members.
    /// </summary>
    RaycastHit HitInfo { get; set; }

    /// <summary>
    /// Position of the user's gaze.
    /// </summary>
    Vector3 Position { get; set; }

    /// <summary>
    /// RaycastHit Normal direction.
    /// </summary>
    Vector3 Normal { get; set; }

	GameObject targetObj {get; set;}
}
