using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolphin : Enemies
{
    Collider2D col;

    AudioManager aM;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
        col = GetComponent<BoxCollider2D>(); // H?mtar hitboxen av fienden - Meher
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
            takeDamage(); // K?r funktionen takeDamage i skriptet som denna ?rver fr?n, Johan.
            die(anim); // K?r funktionen die i arv skriptet, Johan.
            //L?gg in animatorn i inspectorn (Edvin)
        }
    }

    // ?ndrar p? fiendens po?ng och collider - Meher
    public override void die(Animator anim)
    {
        base.die(anim);
        points += 2000;
        col.enabled = false;

    }

}
