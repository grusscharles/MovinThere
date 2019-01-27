using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brocken_Box : MonoBehaviour {

    public GameObject brokenBox;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            Debug.Log("destruction");
            Vector3 pos = collision.gameObject.transform.position;

            Destroy(collision.gameObject);

            GameObject instance = Instantiate(brokenBox, pos, Quaternion.identity);
        }
    }

    private void Update()
    {
        
    }
}
