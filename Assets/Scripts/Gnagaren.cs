using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gnagaren : Enemies //Ärver ifrån Enemies scriptet - Freja Holmgren Jakobsson
{
    AudioManager aM; // referens till våran audiomanager. - Freja Holmgren Jakobsson.

    public Animator anim; //referens till våran animator. - Freja Holmgren Jakobsson.
    void Start()
    {
        aM = FindObjectOfType<AudioManager>(); // Hittar objektet vid namn AudioManager - Freja Holmgren Jakobsson (hjälp av Johan)
        health = 1; // Här stätter vi helth till 1. - Freja Holmgren Jakobsson.
        damage = 1;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "skott") // If sats för vad som händer ifall objektet med denna kod på sig kolliderar med ett annat objekt med tagen "skott" på sig. - Freja Holmgren Jakobsson 
        {
            FindObjectOfType<AudioManager>().Play("Boom"); // Spelar en av våra audios vid namn "Boom". - Freja Holmgren Jakobsson.
            ScreenShakeController.instance.startShake(.1f, .2f); // Denna rad kod refererar till screenShakeController skriptet, som är skrivet av Johan, och startar fuktionen startShake - Freja Holmgren Jakobsson.
            takeDamage(); // Denna kör funktionen "takeDamage" i från Enemies scriptet vilket detta script ärver ifrån - Freja Holmgren Jakobsson
            die(anim); // Denna kör funktionen "die" i arv skriptet - Freja Holmgren Jakobsson.
            
        }


    }
    public override void die(Animator anim)
    {
        base.die(anim);
        points += 20000;
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
