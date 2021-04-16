using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    AudioSource hitSFX;
    
    public float movementSpeed = 5f;

    Vector2 movement;

    [SerializeField]
    float pushForce;

    public bool stunned = false;
    float stunTimer = 0;

    [SerializeField]
    float stunDuration;

    Transform spriteTransform;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        hitSFX = GetComponent<AudioSource>();

        spriteTransform = GetComponentInChildren<SpriteRenderer>().transform;
    }

    void Update()
    {
        if (GameManager.gameState == GameManager.GameState.Play)
        {
            // Get player input
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            // Set the sprite based on its movement input
            anim.SetFloat("Horizontal", movement.x);
            anim.SetFloat("Vertical", movement.y);

            if (stunned)
            {
                stunTimer += Time.deltaTime;
                spriteTransform.Rotate(new Vector3(0f, 0f, 360f / stunDuration) * Time.deltaTime);

                if (stunTimer > stunDuration)
                {
                    stunned = false;
                    stunTimer = 0;
                    spriteTransform.rotation = Quaternion.identity;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        // Move the player based on movement speed
        if (GameManager.gameState == GameManager.GameState.Play && !stunned)
        {
            rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Shopper") && GameManager.gameState == GameManager.GameState.Play)
        {
            stunned = true;

            hitSFX.Play();
            
            Vector2 pushDirection = transform.position - collision.transform.position;
            pushDirection = pushDirection.normalized;

            rb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
        }
    }
}
