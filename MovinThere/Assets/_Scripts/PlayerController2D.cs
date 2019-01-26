using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2D : MonoBehaviour {

    [SerializeField]
    [Tooltip("vitesse de déplacement horizontal et vertical")]
    float moveSpeed = 10f;

    Rigidbody2D rb;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update () {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            rb.transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.transform.position += new Vector3(moveSpeed * Time.deltaTime, 0.0f, 0.0f);
        }
        
    }
}
