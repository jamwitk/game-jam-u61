using System;
using System.Collections;
using Controllers;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public int jumpForce;
        public int speed;
        private Rigidbody2D _rb;
        private Animator _animator;
        
        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            if (GameManager.Instance.IsGameOver)
            {
               _animator.SetBool("IsDeath",true);
                return;
            }
            _animator.SetBool("IsJump",Input.touchCount > 0 || Input.GetMouseButton(0));
            _animator.SetBool("IsGrounded", transform.position.y <= -4f);
            _animator.SetFloat("Speed", _rb.velocity.x);
            if (Input.touchCount > 0 || Input.GetMouseButton(0) && transform.position.y < 4f)
            {
                _rb.AddForce(Vector2.up * jumpForce);
            }
            _rb.AddForce(Vector2.right * speed);
        }

       
    }
}