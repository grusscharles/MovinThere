#define DEBUG_STAIRS_DIRECTION
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour {
    [SerializeField]
    Transform triggerDown, triggerUp;
    [HideInInspector]
    public Vector2 slopeDir;

    void Start ()
    {
        // Get stairs direction
        slopeDir = Vector3.Scale(triggerUp.position, new Vector3(1, 1, 0)) - Vector3.Scale(triggerDown.position, new Vector3(1, 1, 0));
    }

#if DEBUG_STAIRS_DIRECTION
    private void OnDrawGizmos()
    {
        if(triggerDown != null)
        {
            Debug.DrawLine(triggerDown.position, triggerDown.position + new Vector3(slopeDir.x, slopeDir.y, 0));
        }
   
    }
#endif

    void Update () {
		
	}
}
