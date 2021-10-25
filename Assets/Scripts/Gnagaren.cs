using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gnagaren : Enemies //�rver ifr�n Enemies scriptet - Freja Holmgren Jakobsson
{
    AudioManager aM;

    public Animator anim;
    void Start()
    {
        aM = FindObjectOfType<AudioManager>(); // Hittar objektet AudioManager - Freja Holmgren Jakobsson (hj�lp av Johan)
        health = 1;
        damage = 1;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "skott")
        {
            FindObjectOfType<AudioManager>().Play("Boom");
            ScreenShakeController.instance.startShake(.1f, .2f); // Denna rad kod refererar till screenShakeController skriptet, som �r skrivet av Johan, och startar fuktionen startShake - Freja Holmgren Jakobsson.
            takeDamage(); // Denna k�r funktionen "takeDamage" i fr�n Enemies scriptet vilket detta script �rver ifr�n - Freja Holmgren Jakobsson
            die(anim); // Denna k�r funktionen "die" i arv skriptet - Freja Holmgren Jakobsson.
            
        }


    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
