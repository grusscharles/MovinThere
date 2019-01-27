using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsTrigger : MonoBehaviour
{
    Stairs stairs;
    PlayerController2D player;
    bool checkInput = false;

    public bool isUpRight,isUpLeft, isDownEnterTrigger, isExit;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController2D>();
        stairs = GetComponentInParent<Stairs>();
    }
    private void Update()
    {
        if (checkInput && Input.GetKeyDown(KeyCode.S))
            TakeStairs();
    }
    //Enter Stairs
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerCenter")
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
                    checkInput = true;
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
        if(collision.tag == "PlayerCenter")
        {
            if (isUpLeft || isUpRight)
                checkInput = false;
        }
    }

    void TakeStairs()
    {
        player.moveDirStairs = stairs.slopeDir;
        player.isOnSlope = true;
    }

}
