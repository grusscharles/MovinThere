using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsTrigger : MonoBehaviour
{
    public bool isUpTrigger, isDownTrigger;

    int count =0;
    Stairs stairs;
    PlayerController2D player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController2D>();
        stairs = GetComponentInParent<Stairs>();
    }

    //Enter Stairs
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //take stairs
            if (!player.isOnSlope)
            {
                player.moveDirStairs = stairs.slopeDir;
                player.isOnSlope = true;
            }
            //exit stairs
            else if (player.isOnSlope)
            {
                player.isOnSlope = false;
            }
        }
    }

}
