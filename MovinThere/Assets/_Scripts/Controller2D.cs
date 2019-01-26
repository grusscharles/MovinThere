using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Controller2D : MonoBehaviour {

    [SerializeField]
    [Tooltip("vitesse de déplacement horizontal et vertical")]
    float speed = 10f;

    Rigidbody2D rb;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    void Update () {
        Move();
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 moveDir = new Vector2(h * speed, v * speed);

        rb.velocity = moveDir;
    }
}
