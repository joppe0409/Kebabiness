using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    // Variabler för spelarens hp - Meher
    public float playerHP;
    public UI ui; // Refererar till UI skriptet för att använda funktioner för att ändra på health bar - Meher

    public void Start()
    {
        playerHP = 5;
        ui.UpdateHealth(1); // Sätter värdet på healthbaren till 1 - Meher
    }


    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //  Det här är om du har en float i en animation som du vill ändra när den går. - Elin
        animator.SetFloat("Speed", movement.sqrMagnitude);

        // Ändrar på spelaren om x positionen ändras (Basically den flttar på sig, eller 'flip' om man säger så, den speglas. Ta bort om den inte behövs!! - Elin
       /* Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -1;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 1;
        }
        transform.localScale = characterScale;*/

        if (playerHP <= 0)
        {
            PlayerDeath();
        }


    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            TakeDamage();
        }
    }
    
    public void TakeDamage() // Funktion som både ändrar på healthbaren och hp variabeln på spelaren - Meher
    {
        playerHP--;
        ui.UpdateHealth(ui.getHealth() - 0.2f);
    }

    public void PlayerDeath() // Funktion som kallas på när spelaren dör - Meher
    {
        SceneManager.LoadScene("MainMenu");
    }

    private IEnumerator InvincibilityFrames()
    {
        yield return null;
    }



}