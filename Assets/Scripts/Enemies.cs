using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemies : MonoBehaviour
{
    public GameObject floatingText;
    
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

    public int points = 10;

   
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
        print("points" + points);
        points++;

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
        Instantiate(floatingText, transform.position, Quaternion.identity);
        health -= 1;
        print("pang");
      
;
    }
 
    public virtual void die(Animator anim)
    {
        print("sadasd");
        points += 1;
        if(health <= 0)
        {
            
            anim.SetBool("isDead", true); //Frejas
            Instantiate(floatingText, transform.position, Quaternion.identity);
            Destroy(gameObject, 1);
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
            yield return new WaitForSeconds(5);
            
        }

    }

}
