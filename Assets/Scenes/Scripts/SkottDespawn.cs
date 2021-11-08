using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkottDespawn : MonoBehaviour
{
    public float seconds = 2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyBullet()); //Startar en ny courtine, Johan.
    }
    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(seconds); // Väntar så många sekunder som variabeln seconds är satt på, Johan
        Destroy(gameObject); // Förstör objectet scripet ligger på, Johan
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider)
        {
            Destroy(gameObject);
        }
    }
}
