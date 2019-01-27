using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Pass : MonoBehaviour {

    public PlayerController2D Player0;
    public PlayerController2D Player1;

    bool passed = false;

    private void Update()
    {
        if (Player0.triggered && !passed)
        {
            transform.position = new Vector3(4.3f, -2.49f, 0);

            Player0.enabled = false;
            Player1.enabled = true;

            passed = true;
        }
    }

}
