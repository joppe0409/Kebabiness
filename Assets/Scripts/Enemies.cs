using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemies : MonoBehaviour
{
    public GameObject floatingText;

    public int health;
    public GameObject[] enemies;
    public Vector3[] spawnPos;

    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            print("spawn");
            spawnEnemy();
        }
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate()
    {
        moveEnemy(movement);
    }
    void moveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    public void takeDamage()
    {
        health = -1;
        print("pang");
        Instantiate(floatingText, transform.position, Quaternion.identity);
    }
 
    public void die()
    {
        if(health <= 0)
        {
            
            Destroy(gameObject);
        }
    }
    
    public void spawnEnemy()
    {
        var position = spawnPos[UnityEngine.Random.Range(0, spawnPos.Length)];
        var ranEnemies = enemies[UnityEngine.Random.Range(0, enemies.Length)];
        Instantiate(ranEnemies, position, Quaternion.identity);
    }

}
