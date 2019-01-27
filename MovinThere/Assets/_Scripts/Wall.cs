//#define DEBUG_COLLISION

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
    PlayerController2D player;

    [Header("Set in Inspector")]
    [SerializeField]
    bool isRightWall, isLeftWall;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
#if DEBUG_COLLISION
        Debug.Log("wall coll");
#endif
        if(collision.tag == "Player")
        {
#if DEBUG_COLLISION
            Debug.Log("Wall collision left : " + isLeftWall);
            Debug.Log("Wall collision right : " + isRightWall);
#endif
            if (isRightWall)
                player.canMoveRight = false;
            else if (isLeftWall)
                player.canMoveLeft = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (isRightWall)
                player.canMoveRight = true;
            else if (isLeftWall)
                player.canMoveLeft = true;
        }
    }

	void Update () {
		
	}
}
