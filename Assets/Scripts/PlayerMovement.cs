using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // movement going from the x axis (left or right)
    private float horizontal;
    // allows adjustment to player speed
    private float speed = 20f;
    // adjustment to jumping boost for player
    private float jumpingPower = 11f;
    // a confirmation to determine if the player is facing right, otherwise facing left
    private bool isFacingRight = true;
    public Animator anim;

    public SpriteRenderer SpriteRenderer;

    public Sprite Standing;
    public Sprite Crouching;

    public BoxCollider2D Collider;

    public Vector2 StandingSize;
    public Vector2 CrouchingSize;

    //selecting the player's rigid body to justify groundCheck placement
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public bool grounded;

    private void Start()
    {
        Collider = GetComponent<BoxCollider2D>();
        Collider.size = StandingSize;

        SpriteRenderer= GetComponent<SpriteRenderer>();
        SpriteRenderer.sprite = Standing;

        StandingSize = Collider.size;
    }

    void Update()
    {

        // definition for the player confirmed to be grounded (or not)
        grounded = IsGrounded();
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SpriteRenderer.sprite = Crouching;
            Collider.size = CrouchingSize;
            speed = 5f;
            jumpingPower = 0f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            SpriteRenderer.sprite = Standing;
            Collider.size = StandingSize;
            speed = 10f;
            jumpingPower = 5f;
        }
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.x > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (horizontal != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        anim.SetBool("isJumping", !IsGrounded());


        Flip();

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
