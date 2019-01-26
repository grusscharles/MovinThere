using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour {
    [SerializeField]
    Transform battant;

    SpriteSwap spriteSwap;

    private void Awake()
    {
        spriteSwap = GetComponent<SpriteSwap>();

    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Grab();
	}

    void Grab()
    {
        float h = Input.GetAxisRaw("Horizontal");
        Debug.Log(h);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spriteSwap.SwapSprite();
            battant.Rotate(new Vector3(h,0,0));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ok");
    }
}
