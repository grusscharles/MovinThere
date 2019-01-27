using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenObject : MonoBehaviour {
    [SerializeField]
    [Tooltip("Position to go to on next Scene")]
    Transform hiddenPos;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void HideChildren()
    {
        SpriteRenderer[] renderers = transform.GetComponentsInChildren<SpriteRenderer>();

        foreach(SpriteRenderer rend in renderers)
        {
            rend.enabled = false;
        }

        transform.position = hiddenPos.position;
    }
}
