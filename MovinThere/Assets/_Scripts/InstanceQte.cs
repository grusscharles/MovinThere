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

    private bool qteReussi;
     
    
    
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

                if (Input.anyKeyDown)
                {
                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        qteReussi = true;
                        Debug.Log("vous avez appuyé sur le bon bouton à temps !");
                        StartCoroutine(retourAvantDestruction());
                    }

                    else if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
                    {
                        Debug.Log("faut bien se déplacer dans la vie...");
                    }
                    else
                    {
                        qteReussi = false;                        
                        Debug.Log("vous n'avez pas appuyé sur la bonne touche," +
                            " c'était pourtant simple. Vous êtes vraiment mauvais." +
                            " N'éssayez plus, rentrez chez vous. Pensez à votre vie" +
                            " et à la façon dont vous l'avez raté...");
                        StartCoroutine(retourAvantDestruction());
                    }
                }
            }
            else
            {
                qteReussi = false;
                Debug.Log("Le temps est écoulé");
                StartCoroutine(retourAvantDestruction());
            }
        }
    }

    IEnumerator retourAvantDestruction()
    {
        autorisationAppuyer = false;

        if (qteReussi == true)
        {
            nouveauBouton.GetComponent<Image>().color = Color.green;
            nouveauCercle.GetComponent<Image>().color = Color.green;
        }

        if(qteReussi == false)
        {
            nouveauBouton.GetComponent<Image>().color = Color.red;
            nouveauCercle.GetComponent<Image>().color = Color.red;
        }

        yield return new WaitForSeconds(1);
        Destroy(nouveauBouton);
        Destroy(nouveauCercle);
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


