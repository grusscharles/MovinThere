using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxToFill : MonoBehaviour {
    BoxManager boxManager;
    List<Belonging> belongingsList;
    int boxValue;

    private void Awake()
    {
        boxManager = FindObjectOfType<BoxManager>();
    }

    void Start()
    {
        belongingsList = new List<Belonging>();
        boxValue = 0;
    }

    private void OnMouseDown()
    {
        if(boxManager.belonging != null)
        {
            FillBox(boxManager.belonging);
        }
        else
        {
            Debug.LogWarning("[BoxToFill] boxManager.belonging NULL");
        }
    }

    void FillBox(Belonging belonging)
    {
        belonging.transform.position = new Vector3(transform.position.x, transform.position.y, belonging.transform.position.z);
        Debug.Log("[BoxToFill] item name : " + belonging.name);
    }

    public void ComputeValue()
    {
        foreach(Belonging bel in belongingsList)
        {
            boxValue += bel.value;
        }
    }
}
