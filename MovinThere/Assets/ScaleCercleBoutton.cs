using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleCercleBoutton : MonoBehaviour {



    private Vector3 TailleBouton;
    private Vector3 retractation;
    public float rapiditeCercle = 1f;
    
    // Use this for initialization
	void Start () {

        TailleBouton = GameObject.Find("Bouton").transform.localScale;

        retractation = new Vector3(rapiditeCercle, rapiditeCercle);
    }
	
	// Update is called once per frame
	void Update () {
        
        if (gameObject.transform.localScale.x >= TailleBouton.x)
        {
            gameObject.transform.localScale -= retractation * Time.deltaTime;
        }
	}


}
