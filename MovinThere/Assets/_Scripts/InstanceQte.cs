using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstanceQte : MonoBehaviour {


    private GameObject nouveauCanvas;
    public GameObject[] mesBoutons;
    private GameObject nouveauBouton;
    private int boutonRandom;
    private float tempsDattente;
    private float nouveauTempsDattente = 2f;
     
    // Use this for initialization
	void Start () {

        nouveauCanvas = GameObject.Find("Canvas");
	}
	
	// Update is called once per frame
	void Update () {


        /*if (Time.time > tempsDattente)
        {
            boutonRandom = Random.Range(0, 3);
            //print("le bouton instantié est le numéro" + boutonRandom);

            nouveauBouton = Instantiate(mesBoutons[boutonRandom]) as GameObject;
            nouveauBouton.transform.SetParent(nouveauCanvas.transform, false);
            Destroy(nouveauBouton, nouveauTempsDattente);

            tempsDattente = Time.time + nouveauTempsDattente;
        }
        if(nouveauBouton == mesBoutons[0])
        {
            print("le bouton instancié est le numéro 1");
        }

        if (nouveauBouton == mesBoutons[1])
        {
            print("le bouton instancié est le numéro 2");
        }
        if (nouveauBouton == mesBoutons[2])
        {
            print("le bouton instancié est le numéro 3");
        }
        if (nouveauBouton == mesBoutons[3])
        {
            print("le bouton instancié est le numéro 4");
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print("le player est entré dans le trigger");

            boutonRandom = Random.Range(0, 3);
            //print("le bouton instantié est le numéro" + boutonRandom);

            nouveauBouton = Instantiate(mesBoutons[boutonRandom]) as GameObject;
            nouveauBouton.transform.SetParent(nouveauCanvas.transform, false);
            Destroy(nouveauBouton, nouveauTempsDattente);

        }
    }

}
