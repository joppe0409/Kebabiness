using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gnagaren : Enemies //�rver ifr�n Enemies scriptet - Freja Holmgren Jakobsson
{
    AudioManager aM; // referens till v�ran audiomanager. - Freja Holmgren Jakobsson.

    public Animator anim; //referens till v�ran animator. - Freja Holmgren Jakobsson.
    void Start()
    {
        aM = FindObjectOfType<AudioManager>(); // Hittar objektet vid namn AudioManager - Freja Holmgren Jakobsson (hj�lp av Johan)
        health = 1; // H�r st�tter vi helth till 1. - Freja Holmgren Jakobsson.
        damage = 1;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "skott") // If sats f�r vad som h�nder ifall objektet med denna kod p� sig kolliderar med ett annat objekt med tagen "skott" p� sig. - Freja Holmgren Jakobsson 
        {
            FindObjectOfType<AudioManager>().Play("Boom"); // Spelar en av v�ra audios vid namn "Boom". - Freja Holmgren Jakobsson.
            ScreenShakeController.instance.startShake(.1f, .2f); // Denna rad kod refererar till screenShakeController skriptet, som �r skrivet av Johan, och startar fuktionen startShake - Freja Holmgren Jakobsson.
            takeDamage(); // Denna k�r funktionen "takeDamage" i fr�n Enemies scriptet vilket detta script �rver ifr�n - Freja Holmgren Jakobsson
            die(anim); // Denna k�r funktionen "die" i arv skriptet - Freja Holmgren Jakobsson.
            
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
