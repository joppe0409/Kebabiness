using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Enemies
{
    Collider2D col;

    AudioManager aM;
    
    public Animator anim;
    Rigidbody2D rb;
    public float moveForceFrog;

    public Transform bombPos;

    public float Timer;
    float TimerInstance;
    public GameObject Bombgam;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>(); // Hämtar hitboxen av fienden - Meher

        TimerInstance = Timer;
        bombPos = GetComponentInChildren<Transform>();
      
        rb = FindObjectOfType<Rigidbody2D>();
        aM = FindObjectOfType<AudioManager>(); // hittar AudioManager objektet, Johan.
        health = 2;
        damage = 2;
       
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector2.right * moveForceFrog);
        Timer -= Time.deltaTime;
        if(Timer <= 0)
        {
            Instantiate(Bombgam, bombPos.position, Quaternion.identity);
            Timer = TimerInstance;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "skott")
        {
            FindObjectOfType<AudioManager>().Play("Boom");
            print("hej");
            ScreenShakeController.instance.startShake(.1f, .2f); // refererar till screenShakeController skriptet och startar fuktionen startShake, Johan.
            takeDamage(); // Kör funktionen takeDamage i skriptet som denna ärver från, Johan.
            die(anim); // Kör funktionen die i arv skriptet, Johan.
        }

      


    }
    // Ändrar på fiendens poäng och collider - Meher
    public override void die(Animator anim)
    {
        base.die(anim);
        points += 500;
        col.enabled = false;
    }

}
