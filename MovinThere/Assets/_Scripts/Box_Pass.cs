using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Pass : MonoBehaviour {

	void Update () {

        /*
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Box")
            {
                Vector3 pos = collision.gameObject.transform.position;

                Destroy(collision.gameObject);
            }
        }
        */
        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.position = new Vector3 (5, 5, 5);
        }
		
	}
}
