using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxPersistTest : MonoBehaviour {
    BoxManager boxManager;

    private void Awake()
    {
        boxManager = FindObjectOfType<BoxManager>(); 
    }
    // Use this for initialization
    void Start () {
        GetComponent<Button>().onClick.AddListener(PrintBelongings);
    }

    void PrintBelongings()
    {
        Debug.Log("[BoxPersistTest] Print");
        boxManager.PrintBelongings();
    }

}
