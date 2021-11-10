using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    AudioManager aM;
    Vector2 movement;

    // Variabler f�r spelarens hp - Meher
    [SerializeField]
    private bool isInvincible;
    [SerializeField]
    private float iFrames;
    public float playerHP;

    public GameObject player;
    public ParticleSystem explosion;

    public UI ui; // Refererar till UI skriptet f�r att anv�nda funktioner f�r att �ndra p� health bar - Meher

    public void Start()
    {
        aM = FindObjectOfType<AudioManager>(); // hittar AudioManager objektet, Johan.

        playerHP = 5;
        ui.UpdateHealth(1); // S�tter v�rdet p� healthbaren till 1 - Meher
        Time.timeScale = 1;
        FindObjectOfType<AudioManager>().Play("l�t");
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

        // N�r spelaren d�r anv�nds funktionen fr�n "UI" f�r att h�mta DeathScreen - Meher
        if (playerHP <= 0)
        {
            ui.PlayerDeath();
        }

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // F�r spelaren att ta skada om den nuddar en fiende, och f�rst�r fienden - Meher
        if (collision.gameObject.tag == "enemy")
        {
            Instantiate(explosion, player.transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("explosionSound");
            Destroy(collision.gameObject);
            TakeDamage();
        }

    }
    // Funktion som b�de �ndrar p� healthbaren och hp variabeln p� spelaren - Meher
    public void TakeDamage() 
    {
        if (isInvincible == true) return;
        playerHP--;
        ui.UpdateHealth(ui.getHealth() - 0.2f); // Tar ned v�rdet med en femtedel s� att man f�r 5HP - Meher
        StartCoroutine(InvincibilityFrames());
    }

    // IEnumerator som f�r spelaren att vara od�dlig i en viss m�ngd tid som man kan �ndra p� inspektorn - Meher
    private IEnumerator InvincibilityFrames()
    {
        isInvincible = true;

        yield return new WaitForSeconds(iFrames);

        isInvincible = false;
    }



}