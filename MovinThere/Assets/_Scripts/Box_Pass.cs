using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Pass : MonoBehaviour {

    bool triggered = false;
    Vector3 boxPos = new Vector3(0,0,0);
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            transform.GetChild(0).transform.position = new Vector3(8.67f, 0.76f, 0f);
        }
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trigger_Pass1" && triggered == false)
        {
            Debug.Log("TAPE le trigger");

            triggered = true;

            Vector3 pos = new Vector3(4f, -2f, 0f);

            transform.position = pos;            
        }
    }
    */
}
