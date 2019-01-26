using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour {

    CameraBehaviour cam;

    private void Awake()
    {
        cam = FindObjectOfType<CameraBehaviour>();   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            cam.SetCam();
        }
    }
}
