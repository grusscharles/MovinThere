using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belonging : MonoBehaviour {
    BoxManager boxManager;
    //SpriteRenderer rend;
    BoxToFill parentBox;

    [Tooltip("Score que rapporte cet objet")]
    public int value;
    [SerializeField]
    Color highlightColor;
    [HideInInspector]
    public bool isStored = false;
    private void Awake()
    {
        //rend = GetComponent<SpriteRenderer>();
        boxManager = FindObjectOfType<BoxManager>();
    }

    private void OnMouseDown()
    {
        SelectBelonging();
    }

    void SelectBelonging()
    {
        boxManager.GetBelonging(this);
        //rend.color = highlightColor;
    }

    //Validation
    public void AddToBox()
    {
        parentBox = transform.GetComponentInParent<BoxToFill>();
        parentBox.belongingsList.Add(this);
    }

}
