using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsTrigger : MonoBehaviour
{
    Stairs stairs;
    PlayerController2D player;
    public bool isUp, isEnter, isExit;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController2D>();
        stairs = GetComponentInParent<Stairs>();
    }

    //Enter Stairs
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //take stairs
            if (!player.isOnSlope && isEnter)
            {
                player.moveDirStairs = stairs.slopeDir;
                player.isOnSlope = true;

                //avoid player floating towards right dir when going downstairs
                if (isUp)
                {
                    player.canMoveRight = false;
                }
            }
            //exit stairs
            else if (player.isOnSlope && isExit)
            {
                player.isOnSlope = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isUp)
        {
            player.canMoveRight = true;
        }
    }

}
