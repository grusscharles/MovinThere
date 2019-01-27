using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour {

    HiddenObject hidden;
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
        hidden = FindObjectOfType<HiddenObject>();
    }

    public void GetBelonging(Belonging bel)
    {
        belonging = bel;
    }
    
    //Debug
    public void PrintBelongings()
    {

        if (boxes.Length > 0)
        {

            foreach (BoxToFill box in boxes)
            {
                foreach (Belonging bel in box.belongingsList)
                {
                    Debug.Log("items stored in " + box.name + " : " + bel.name);
                }
            }
        }
        else
        {
            Debug.Log("boxes is empty");
        }
     
    }

    #region Boxes Validation
    //Validate boxes
    public void ValidateBoxes()
    {
        AddBelongingsToBoxes();
        ComputeBoxesValues();
        hidden.HideChildren();
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
