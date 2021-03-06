using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;


    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


        //  Det h?r ?r om du har en float i en animation som du vill ?ndra n?r den g?r. - Elin
        animator.SetFloat("Speed", movement.sqrMagnitude);

        // ?ndrar p? spelaren om x positionen ?ndras (Basically den flttar p? sig, eller 'flip' om man s?ger s?, den speglas. Ta bort om den inte beh?vs!! - Elin
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -1;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 1;
        }
        transform.localScale = characterScale;

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


}