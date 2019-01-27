using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2D : MonoBehaviour {

    [SerializeField]
    [Tooltip("vitesse de déplacement horizontal")]
    Vector2 moveSpeed = new Vector2(3.0f, 0.0f);
    [SerializeField]
    [Tooltip("vitesse de déplacement dans escaliers")]
    float moveSpeedDiag = 1f;

    [HideInInspector]
    public bool isOnSlope = false;
    [HideInInspector]
    public bool canMoveRight, canMoveLeft;
    [HideInInspector]
    public Vector2 moveDirStairs;

    Rigidbody2D rb;

    private void Start()
    {
        canMoveRight = true;
        canMoveLeft = true;
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

        if (Input.GetKey(KeyCode.Q) && canMoveLeft)
        {
            rb.MovePosition(rb.position - direction * moveSpeedDiag * Time.deltaTime * moveDirStairs);
        }
        if (Input.GetKey(KeyCode.D) && canMoveRight)
        {
            rb.MovePosition(rb.position + direction * moveSpeedDiag * Time.deltaTime * moveDirStairs);
        }

    }

    //Horizontal Movement
    private void Move()
    {
        if (Input.GetKey(KeyCode.Q) && canMoveLeft)
        {
            rb.MovePosition(rb.position + moveSpeed * Time.deltaTime * -1);
        }
        if (Input.GetKey(KeyCode.D) && canMoveRight)
        {
            rb.MovePosition(rb.position + moveSpeed * Time.deltaTime);
        }
        
    }

}
