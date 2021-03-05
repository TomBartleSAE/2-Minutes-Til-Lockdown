using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    
    [SerializeField]
    float movementSpeed = 5f;

    Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Get player input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Set the sprite based on its movement input
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
    }

    private void FixedUpdate()
    {
        // Move the player based on movement speed
        if (!GameManager.gameOver)
        {
            rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
        }
    }
}
