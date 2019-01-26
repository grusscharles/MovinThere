using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsTrigger : MonoBehaviour {

    PlayerController2D player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController2D>();    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Coucou");

        //Toggle player rigidbody dynamic / kinematic
        if(collision.gameObject.tag == "Player")
        {
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            rb.isKinematic = !rb.isKinematic;
            rb.useFullKinematicContacts = !rb.useFullKinematicContacts;
        }
    }

}
