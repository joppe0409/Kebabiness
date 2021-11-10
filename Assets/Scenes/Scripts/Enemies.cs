using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemies : MonoBehaviour
{
    public GameObject floatingText; // Detta �r en referens till v�ran prefab "floatingText". - Freja Holmgren Jakobsson.
    
    public int health;
    public GameObject[] enemies;
    public GameObject frog;
    public Vector3[] spawnPos;
    public Vector3 frogPos;
   

    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 5f;

    public bool spawnTrue;

    public float damage;

    public static int points = 0;

   
    // Start is called before the first frame update
    void Start()
    {
      
        rb = this.GetComponent<Rigidbody2D>();
        StartCoroutine(SpawnEnemies());
        StartCoroutine(Frog());

    }

    // Update is called once per frame
    void Update()
    {
        print("points" + points); // -Meher

        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
        moveEnemy(movement);

       
    }
   
    void moveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    public void takeDamage()
    {
        Instantiate(floatingText, transform.position, Quaternion.identity); //H�r instaniserar jag prefaben f�r "floatingtext", Jag s�tter den p� samma position som v�ra enemies med hj�lp av Quarternation vilket i princip �r "deafult" v�rdet av ett objekts rotation. - Freja Holmgren Jakobsson.
        health -= 1;
        print("pang");
      
;
    }

    // Denna funktion �r en virtual s� att alla fiender som �rver detta skript kan ge olika m�ngder po�ng n�r de d�r - Meher
    public virtual void die(Animator anim)
    {
        
        if(health <= 0)
        {
            
            anim.SetBool("isDead", true); // H�r s�ger jag �t v�ran animatior att transitionen med boolen isDead ska starta samt att kommande animation skall spelas. - Freja Holmgren Jakobsson
            Instantiate(floatingText, transform.position, Quaternion.identity); //H�r lika som f�rut instaniserar jag prefaben f�r "floatingtext", Jag s�tter ocks� den p� samma position som v�ra enemies �terigen med hj�lp av Quarternation vilket, som tidigare n�mnt, i princip �r "deafult" v�rdet av ett objekts rotation. - Freja Holmgren Jakobsson.
            Destroy(gameObject, 0.5f);
        }
        
    }
    
    IEnumerator SpawnEnemies()
    {
        while(spawnTrue == true)
        {
            var position = spawnPos[UnityEngine.Random.Range(0, spawnPos.Length)];
            var ranEnemies = enemies[UnityEngine.Random.Range(0, enemies.Length)];
            Instantiate(ranEnemies, position, Quaternion.identity);
            yield return new WaitForSeconds(1);
        }
   
    }
    IEnumerator Frog()
    {
        while (spawnTrue == true)
        {
            print("Ribbit");
            Instantiate(frog, frogPos, Quaternion.identity);
            yield return new WaitForSeconds(10);
            
        }

    }

}
