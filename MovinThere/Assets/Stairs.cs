using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour {

    Transform triggerDown, triggerUp;
    [HideInInspector]
    public Vector3 slopeDir;

    private void Awake()
    {
        triggerDown = transform.GetChild(0);
        triggerUp = transform.GetChild(1);
    }

    // Use this for initialization
    void Start () {

        slopeDir = Vector3.Scale(triggerUp.position, new Vector3(1, 1, 0)) - Vector3.Scale(triggerDown.position, new Vector3(1, 1, 0));
    }

    private void OnDrawGizmos()
    {
        if(triggerDown != null)
        {
            Debug.DrawLine(triggerDown.position, triggerDown.position + slopeDir);
        }
   
    }
    // Update is called once per frame
    void Update () {
		
	}
}
