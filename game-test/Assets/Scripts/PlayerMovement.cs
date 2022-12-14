using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Components
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D coll;
    //Variables
    private float dirX = 0f;
    [SerializeField] private float jumpHeight = 14f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private AudioSource jumpSoundEffekt;

    private enum AnimationState 
    {
        idle,
        running,
        jumping,
        falling
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>(); 
    }

    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            jumpSoundEffekt.Play();
        } 
        

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        AnimationState state; 

        if(dirX > 0)
        {
            state = AnimationState.running;
            spriteRenderer.flipX = false;
        }
        else if(dirX < 0)
        {
            state = AnimationState.running;
            spriteRenderer.flipX = true;
        }
        else
        {
            state = AnimationState.idle;
        }

        if(rb.velocity.y > 0.1f)
        {
            state = AnimationState.jumping;
        }
        else if(rb.velocity.y < -0.1f)
        {
            state = AnimationState.falling;
        }
        animator.SetInteger("state", (int)(state));
    }

    private bool isGrounded()
    {
        //Creates second collider just slighty below the player collider
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}
