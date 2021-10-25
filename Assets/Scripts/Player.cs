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

    // Variabler f�r spelarens hp - Meher
    public float playerHP;
    public UI ui; // Refererar till UI skriptet f�r att anv�nda funktioner f�r att �ndra p� health bar - Meher

    public void Start()
    {
        playerHP = 5;
        ui.UpdateHealth(1); // S�tter v�rdet p� healthbaren till 1 - Meher
    }


    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //  Det h�r �r om du har en float i en animation som du vill �ndra n�r den g�r. - Elin
        animator.SetFloat("Speed", movement.sqrMagnitude);

        // �ndrar p� spelaren om x positionen �ndras (Basically den flttar p� sig, eller 'flip' om man s�ger s�, den speglas. Ta bort om den inte beh�vs!! - Elin
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
    
    public void TakeDamage() // Funktion som b�de �ndrar p� healthbaren och hp variabeln p� spelaren - Meher
    {
        playerHP--;
        ui.UpdateHealth(ui.getHealth() - 0.2f);
    }

    public void PlayerDeath() // Funktion som kallas p� n�r spelaren d�r - Meher
    {
        SceneManager.LoadScene("MainMenu");
    }

    private IEnumerator InvincibilityFrames()
    {
        yield return null;
    }



}