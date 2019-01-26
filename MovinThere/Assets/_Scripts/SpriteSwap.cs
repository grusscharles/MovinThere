using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwap : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Sprites list")]
    List<Sprite> sprites;

    int currentSpriteIndex;
    SpriteRenderer sprtRend;

    private void Awake()
    {
        sprtRend = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        sprtRend.sprite = sprites[0];
        currentSpriteIndex = 0;
    }

    public void SwapSprite()
    {
        if (currentSpriteIndex != sprites.Count - 1)
        {
            sprtRend.sprite = sprites[currentSpriteIndex + 1];
            currentSpriteIndex += 1;
        }
        else
        {
            sprtRend.sprite = sprites[0];
            currentSpriteIndex = 0;
        }
    }
}
	
