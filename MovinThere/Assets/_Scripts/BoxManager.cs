using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour {

    HiddenObject hidden;
    Belonging[] belongings;
    BoxToFill[] boxes;

    [SerializeField]
    GameObject validationButton;
    [HideInInspector]
    public BoxToFill box;

    [HideInInspector]
    public Belonging belonging;

    bool itemsStored = false;

    private void Awake()
    {
        validationButton.SetActive(false);
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

    //Set all belongings color to original
    public void SetBelongingsColor()
    {
        foreach(Belonging bel in belongings)
        {
            bel.SetOriginalColor();
        }
    }

    #region Check if all items are stored
    private void Update()
    {
        if (!itemsStored)
        {
            CheckBelongings();
        }
    }
    
    //Check if all items are stored
    void CheckBelongings()
    {
        int itemsStoredNumber = 0;
        //Check if all items are stored
        foreach (Belonging bel in belongings)
        {
            if (bel.isStored)
            {
                itemsStoredNumber += 1;
            }
        }
        //all items stored
        if (itemsStoredNumber > belongings.Length - 1)
        {
            EnableValidation();
        }
    }
    #endregion

    #region Boxes Validation

    //Enable validation Button
    void EnableValidation()
    {
        itemsStored = true;
        validationButton.SetActive(true);
    }

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
