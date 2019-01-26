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

    private bool isOnSlope = false;

    Stairs stairs;
    Vector3 moveDirStairs;
    Rigidbody2D rb;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update () {
        
        //player on horizontal floor
        if (!isOnSlope)
        {
            Move();
        }
        //player trying to go upstairs
        else
        {
            MoveDiag();
        }
        
    }

    //Stairs triggers
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Enter stairs
        if(collision.gameObject.tag == "TriggerDown")
        {
            Debug.Log("[PlayerController] StairsEnter");
            isOnSlope = true;
            stairs = collision.GetComponentInParent<Stairs>();
            moveDirStairs = stairs.slopeDir;
        }
        //Exit stairs
        else if(collision.gameObject.tag == "TriggerUp")
        {
            Debug.Log("[PlayerController] StairsExit");
            isOnSlope = false;
        }

    }

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
