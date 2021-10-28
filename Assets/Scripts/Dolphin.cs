using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolphin : Enemies
{

    AudioManager aM;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        aM = FindObjectOfType<AudioManager>(); // hittar AudioManager objektet, Johan.
        health = 1;
        damage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "skott")
        {
            FindObjectOfType<AudioManager>().Play("Boom");
            ScreenShakeController.instance.startShake(.1f, .2f); // refererar till screenShakeController skriptet och startar fuktionen startShake, Johan.
            takeDamage(); // Kör funktionen takeDamage i skriptet som denna ärver från, Johan.
            die(anim); // Kör funktionen die i arv skriptet, Johan.
            //Lägg in animatorn i inspectorn (Edvin)
        }
    }

    public override void die(Animator anim)
    {
        base.die(anim);
        points += 2000;
    }

}
