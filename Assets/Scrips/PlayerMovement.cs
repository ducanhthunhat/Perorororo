using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private bool isFacingRight = true;
    [SerializeField] float speedMove = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float PushForce = 5f;
    [SerializeField] Vector2 boxSize = new Vector2(0.5f, 0.1f);
    [SerializeField] float castDistance = 0.2f;
    private float moveX;
    [SerializeField] public LayerMask GroundLayer;
    private bool isGrounded = false;
    private bool CanFly = false;
    public Transform pointCheck;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        isGrounded = Physics2D.BoxCast(pointCheck.position, boxSize, 0f, Vector2.down, castDistance, GroundLayer);
        moveX = Input.GetAxisRaw("Horizontal");
        UpdateAnimationState();
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (moveX > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveX < 0 && isFacingRight)
        {
            Flip();
        }

        if (CanFly)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.velocity = new Vector2(rb.velocity.x, PushForce);
            }
        }
    }
    void FixedUpdate()
    {
        Move();

    }

    private void Move()
    {
        rb.velocity = new Vector2(moveX * speedMove, rb.velocity.y);
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void UpdateAnimationState()
    {
        anim.SetFloat("Speed", Mathf.Abs(moveX));
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("vVelocity", rb.velocity.y);

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(pointCheck.position + Vector3.down * castDistance, boxSize);
    }
    void OnEnable()
    {
        FlyItem.Can_fly += EnableFly;
    }

    void OnDisable()
    {
        FlyItem.Can_fly -= EnableFly;
    }

    void EnableFly()
    {
        CanFly = true;
    }



}
