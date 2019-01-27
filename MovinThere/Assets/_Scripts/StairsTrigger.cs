using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsTrigger : MonoBehaviour
{
    Stairs stairs;
    PlayerController2D player;

    public bool isUpRight,isUpLeft, isDownEnterTrigger, isExit;

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
            if (!player.isOnSlope)
            {
                //Go upstairs
                if (isDownEnterTrigger)
                {
                    TakeStairs();
                }
                //Go downstairs
                else if(isUpLeft || isUpRight)
                {
                    TakeStairs();
                }

            }
            //exit stairs
            else if (player.isOnSlope && isExit)
            {
                Debug.Log("GO");
                player.isOnSlope = false;
            }
        }
    }

    void TakeStairs()
    {
        player.moveDirStairs = stairs.slopeDir;
        player.isOnSlope = true;
    }

}
