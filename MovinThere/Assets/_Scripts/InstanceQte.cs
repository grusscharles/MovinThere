using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstanceQte : MonoBehaviour {

    // récupération du Canva
    private GameObject nouveauCanvas;

    // récupération de l'objet bouton QTE
    public GameObject boutonQte;
    private GameObject nouveauBouton;

    // récupération de l'objet cercle
    public GameObject cercleTempsLimite;
    private GameObject nouveauCercle;

    // pour récupérer les scale du bouton et du cercle
    private Vector3 tailleBouton;

    // pour décrémenter le scale du cercle
    private Vector3 retractation;
    public float vitesseRetractation = 0.3f;

    // autorisations déclencher une fois le Trigger + appuyer touche.
    private bool boutonDejaInstancie = false;
    private bool autorisationAppuyer = false;
     
    
    
    // Use this for initialization
	void Start () {

        tailleBouton = boutonQte.transform.localScale;

        retractation = new Vector3(vitesseRetractation, vitesseRetractation);
        
    }
	
	// Update is called once per frame
	void Update () {

        if (autorisationAppuyer == true)
        {
            if (nouveauCercle.transform.localScale.x >= tailleBouton.x)
            {
                nouveauCercle.transform.localScale -= retractation * Time.deltaTime;

                if (Input.GetKey(KeyCode.A))
                {
                    Destroy(nouveauBouton);
                    Destroy(nouveauCercle);
                    autorisationAppuyer = false;
                    Debug.Log("vous avez appuyé sur le bon bouton à temps !");
                }
                
            }
            else
            {
                Destroy(nouveauBouton);
                Destroy(nouveauCercle);
                autorisationAppuyer = false;
                Debug.Log("Vous n'avez pas appuyé sur le bon bouton à temps !");
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


