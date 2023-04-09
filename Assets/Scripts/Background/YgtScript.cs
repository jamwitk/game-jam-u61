using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YgtScript : MonoBehaviour
{
    
    public int jumpForce;
    private Rigidbody2D _rb;
        
        
    private Animator _animator;
    [SerializeField] private Transform groundCheck;

    [SerializeField] private float groundCheckRadius;

    public float speed = 2f;

    public float jump;
    public bool IsJump;
        
    // [SerializeField] private float jumpForce = 10f;

    [SerializeField] private LayerMask collisionMask;
        
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
        
    private void Update()
    {
        var inputX = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(speed * inputX, _rb.velocity.y);

        if (Input.GetKeyDown("Jump")&& IsJump==false)
        {
            _rb.AddForce(new Vector2(_rb.velocity.x,jump));
            

        }
        
        _animator.SetBool("IsGrounded",inputX!=0);
        


    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            _animator.SetBool("IsJump",!IsGrounded());
            
            

        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            _animator.SetBool("IsJump",IsGrounded());

        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionMask);
    }
}

