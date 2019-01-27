using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belonging : MonoBehaviour {
    BoxManager boxManager;
    SpriteRenderer rend;
    BoxToFill parentBox;
    Color originalColor;

    [Tooltip("Score que rapporte cet objet")]
    public int value;
    [SerializeField]
    Color highlightColor;
    [HideInInspector]
    public bool isStored = false;

    private void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
        originalColor = rend.color;
        boxManager = FindObjectOfType<BoxManager>();
    }

    private void OnMouseDown()
    {
        SelectBelonging();
    }

    void SelectBelonging()
    {
        boxManager.SetBelongingsColor();
        boxManager.GetBelonging(this);
        rend.color = highlightColor;
    }

    public void SetOriginalColor()
    {
        rend.color = originalColor;
    }

    //Validation
    public void AddToBox()
    {
        parentBox = transform.GetComponentInParent<BoxToFill>();
        parentBox.belongingsList.Add(this);
    }

}
