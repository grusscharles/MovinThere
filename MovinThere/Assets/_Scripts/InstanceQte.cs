using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstanceQte : MonoBehaviour {


    private GameObject nouveauCanvas;
    //public GameObject[] mesBoutons;
    public GameObject boutonQte;
    private GameObject nouveauBouton;

    public GameObject cercleTempsLimite;
    private GameObject nouveauCercle;

    public float vitesseRetractationCercle = 0.25f;

    private int boutonRandom;
    private bool boutonDejaInstancie = false;
    private bool autorisationAppuyer = false;
     
    // Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        if (autorisationAppuyer == true)
        {

            if (Input.GetKeyDown(KeyCode.A))
            {
                Destroy(nouveauBouton);
                Destroy(nouveauCercle);

                Debug.Log("félicitation ! tu as appuyé sur la bonne touche à temps");
            }
            else
            {
                nouveauCercle.gameObject.transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * vitesseRetractationCercle;
                Destroy(nouveauBouton, 5);
                Destroy(nouveauCercle, 5);


            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && boutonDejaInstancie == false)
        {
            Debug.Log("le Player a traversé le Trigger");

            nouveauCanvas = GameObject.Find("Canvas");

            nouveauCercle = Instantiate(cercleTempsLimite) as GameObject;
            nouveauCercle.transform.SetParent(nouveauCanvas.transform, false);

            nouveauBouton = Instantiate(boutonQte) as GameObject;
            nouveauBouton.transform.SetParent(nouveauCanvas.transform, false);

            boutonDejaInstancie = true;
            autorisationAppuyer = true;
        }
    }
}


