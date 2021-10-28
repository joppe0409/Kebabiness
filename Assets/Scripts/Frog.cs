using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Enemies
{
    AudioManager aM;
    
    public Animator anim;

    Rigidbody2D rb;
    public float moveForceFrog;
    // Start is called before the first frame update
    void Start()
    {
        rb = FindObjectOfType<Rigidbody2D>();
        aM = FindObjectOfType<AudioManager>(); // hittar AudioManager objektet, Johan.
        health = 2;
        damage = 2;
       
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector2.right * moveForceFrog);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "skott")
        {
            FindObjectOfType<AudioManager>().Play("Boom");
            ScreenShakeController.instance.startShake(.1f, .2f); // refererar till screenShakeController skriptet och startar fuktionen startShake, Johan.
            takeDamage(); // Kör funktionen takeDamage i skriptet som denna ärver från, Johan.
            die(anim); // Kör funktionen die i arv skriptet, Johan.
        }


    }
   
}
