//using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;
        [SerializeField] private float Walk;
        private Rigidbody2D _rigidbody2D;
        private Animator _animator;

        private bool grounded;
        private bool started;
        private bool Walking;
       

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>(); 
            _animator = GetComponent<Animator>();
            grounded = true;
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Space))

            {
                if (started && grounded)
                {
                    _animator.SetTrigger("Walk");
                    grounded = false;
                    Walking = true;
                }
                else
                {
                    _animator.SetBool("GameStarted", true);
                    started = true;
                }
            }

            if (grounded)
            {
                _animator.SetBool("Grounded", grounded);
            }
        }

        private void FixedUpdate()
        {
            if (started)
            {
                _rigidbody2D.velocity = new Vector2(speed, _rigidbody2D.velocity.y);
            }
            if (Walking)
            {
                _rigidbody2D.AddForce(new Vector2(0f, Walk));
                Walking = false;
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                grounded = true;
            }
        }
    }


}
