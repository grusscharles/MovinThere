using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxFriction : MonoBehaviour {

    public Rigidbody2D rb;
    Rigidbody2D rbBox;
    public float frictionCoef = 1.0f;
    private Vector2 vitesse;

    private void Awake()
    {
        rbBox = GetComponent<Rigidbody2D>();
    }

    void Update () {

        vitesse = rb.velocity;

        Debug.Log(vitesse);

        rbBox.AddForce(vitesse);
	}
}
