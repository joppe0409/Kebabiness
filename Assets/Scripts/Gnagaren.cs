using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gnagaren : Enemies //Ärver ifrån Enemies scriptet - Freja Holmgren Jakobsson
{
    AudioManager aM;

    public Animator anim;
    void Start()
    {
        aM = FindObjectOfType<AudioManager>(); // Hittar objektet AudioManager - Freja Holmgren Jakobsson (hjälp av Johan)
        health = 1;
        damage = 1;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "skott")
        {
            FindObjectOfType<AudioManager>().Play("Boom");
            ScreenShakeController.instance.startShake(.1f, .2f); // Denna rad kod refererar till screenShakeController skriptet, som är skrivet av Johan, och startar fuktionen startShake - Freja Holmgren Jakobsson.
            takeDamage(); // Denna kör funktionen "takeDamage" i från Enemies scriptet vilket detta script ärver ifrån - Freja Holmgren Jakobsson
            die(anim); // Denna kör funktionen "die" i arv skriptet - Freja Holmgren Jakobsson.
            
        }


    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
