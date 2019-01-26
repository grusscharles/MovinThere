using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerTest : MonoBehaviour {

    public float movin = 10.0f;
    Rigidbody2D rb;
    Vector2 velocity = new Vector2(10.0f, 0.0f);

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update () {

        if (Input.GetKey(KeyCode.Q))
        {
            GetComponent<Rigidbody2D>().MovePosition(rb.position + velocity * Time.deltaTime * -1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().MovePosition(rb.position + velocity * Time.deltaTime);
        }
    }
}
