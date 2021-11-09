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

    // Variabler för spelarens hp - Meher
    [SerializeField]
    private bool isInvincible;
    [SerializeField]
    private float iFrames;
    public float playerHP;

    public GameObject player;
    public ParticleSystem explosion;

    public UI ui; // Refererar till UI skriptet för att använda funktioner för att ändra på health bar - Meher

    public void Start()
    {
        aM = FindObjectOfType<AudioManager>(); // hittar AudioManager objektet, Johan.

        playerHP = 5;
        ui.UpdateHealth(1); // Sätter värdet på healthbaren till 1 - Meher
        Time.timeScale = 1;
        FindObjectOfType<AudioManager>().Play("låt");
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

        // När spelaren dör används funktionen från "UI" för att hämta DeathScreen - Meher
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
        // Får spelaren att ta skada om den nuddar en fiende, och förstör fienden - Meher
        if (collision.gameObject.tag == "enemy")
        {
            Instantiate(explosion, player.transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("explosionSound");
            Destroy(collision.gameObject);
            TakeDamage();
        }

    }
    // Funktion som både ändrar på healthbaren och hp variabeln på spelaren - Meher
    public void TakeDamage() 
    {
        if (isInvincible == true) return;
        playerHP--;
        ui.UpdateHealth(ui.getHealth() - 0.2f); // Tar ned värdet med en femtedel så att man får 5HP - Meher
        StartCoroutine(InvincibilityFrames());
    }

    // IEnumerator som får spelaren att vara odödlig i en viss mängd tid som man kan ändra på inspektorn - Meher
    private IEnumerator InvincibilityFrames()
    {
        isInvincible = true;

        yield return new WaitForSeconds(iFrames);

        isInvincible = false;
    }



}