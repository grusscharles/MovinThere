using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2D : MonoBehaviour {

    [SerializeField]
    [Tooltip("vitesse de déplacement horizontal")]
    float moveSpeed = 3f;
    [SerializeField]
    [Tooltip("vitesse de déplacement dans escaliers")]
    float moveSpeedDiag = 1f;

    public bool isOnSlope = false;
    public Vector3 moveDirStairs;

    Rigidbody2D rb;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update () {
        
        //horizontal movement
        if (!isOnSlope)
        {
            Move();
        }
        //player takes stairs
        else
        {
            MoveDiag();
        }

    }

    //Go Upstairs
    private void MoveDiag()
    {
        //float pour savoir si l'escalier monte vers la gauche ou vers la droite
        float direction = Mathf.Sign(moveDirStairs.x);

        if (Input.GetKey(KeyCode.Q))
        {
            rb.transform.position = rb.transform.position - direction * moveSpeedDiag * Time.deltaTime * moveDirStairs;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.transform.position = rb.transform.position + direction * moveSpeedDiag * Time.deltaTime * moveDirStairs;
        }
    }

    //Horizontal Movement
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
