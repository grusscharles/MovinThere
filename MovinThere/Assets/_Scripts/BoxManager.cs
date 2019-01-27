using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour {

    Belonging[] belongings;
    BoxToFill[] boxes;

    [HideInInspector]
    public BoxToFill box;

    [HideInInspector]
    public Belonging belonging;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start () {
        //Get all boxes and belongings
        belongings = FindObjectsOfType<Belonging>();
        boxes = FindObjectsOfType<BoxToFill>();
    }

    public void GetBelonging(Belonging bel)
    {
        belonging = bel;
    }

    #region Boxes Validation
    //Validate boxes
    public void ValidateBoxes()
    {
        AddBelongingsToBoxes();
        ComputeBoxesValues();
    }

    void AddBelongingsToBoxes()
    {
        foreach (Belonging b in belongings)
        {
            b.AddToBox();
        }
    }

    void ComputeBoxesValues()
    {
        foreach(BoxToFill b in boxes)
        {
            b.ComputeValue();
        }
    }

    #endregion
}
