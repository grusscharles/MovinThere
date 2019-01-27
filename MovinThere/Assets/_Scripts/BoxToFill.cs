//#define DEBUG

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxToFill : MonoBehaviour {
    BoxManager boxManager;
    int boxValue;

    [SerializeField]
    int boxOwnValue = 1;
    [HideInInspector]
    public List<Belonging> belongingsList;

    private void Awake()
    {
        boxManager = FindObjectOfType<BoxManager>();
    }

    void Start()
    {
        belongingsList = new List<Belonging>();
        boxValue = boxOwnValue;
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
        belonging.transform.SetParent(transform);
    }

    //Validation
    public void ComputeValue()
    {
        foreach(Belonging bel in belongingsList)
        {
            boxValue += bel.value;
        }
#if DEBUG
        foreach (Belonging bel in belongingsList)
        {
            Debug.Log("belongings in " + gameObject.name + "  : " + bel.name);
        }
        Debug.Log(gameObject.name+ " value : " + boxValue);
#endif
    }
}
