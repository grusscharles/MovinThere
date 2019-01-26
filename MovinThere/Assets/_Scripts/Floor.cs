using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {
    [SerializeField]
    Collider2D floorCol;

    void Start () {
        floorCol.enabled = false;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        floorCol.enabled = true;
    }

    void Update () {
		
	}
}
