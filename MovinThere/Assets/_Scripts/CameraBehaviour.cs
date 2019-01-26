using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    bool followPlayer = false;
    Vector3 offset;
    PlayerController2D player;
    float camXPos, camZPos;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController2D>();
        camXPos = transform.position.x;
        camZPos = transform.position.z;
    }

	
	void Update () {

        if (followPlayer)
        {
            FollowPlayer();
        }
	}

    public void SetCam()
    {
        offset = transform.position - player.transform.position;
        followPlayer = true;
    }

    void FollowPlayer()
    {
        transform.position = new Vector3(camXPos, player.transform.position.y + offset.y, camZPos);
    }
}

