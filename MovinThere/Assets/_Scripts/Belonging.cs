using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belonging : MonoBehaviour {
    BoxManager boxManager;
    SpriteRenderer rend;

    [Tooltip("Score que rapporte cet objet")]
    public int value;

    private void Awake()
    {
        boxManager = FindObjectOfType<BoxManager>();
    }

    private void OnMouseDown()
    {
        SelectBelonging();
    }

    void SelectBelonging()
    {
        boxManager.GetBelonging(this);

    }

}
