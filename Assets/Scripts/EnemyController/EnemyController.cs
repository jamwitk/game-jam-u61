//using System.Collections;
//using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] private float speed = 10f;
    [SerializeField] private float Walk;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    public int health = 1;
    public int damage = 1;
    public bool isStrong = false;

    private bool isDead = false;
    private bool isAttacking = false;
    private bool grounded;
    private bool started;
    private bool Walking;
    private float lastAttackTime = 0f;
    private float attackCooldown = 2f;


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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            if (!enemy.isDead)
            {
                enemy.TakeDamage(damage);
            }
        }
        else if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            TakeDamage(1);
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
        if (!isDead && !isAttacking)
        {
            if (Time.time > lastAttackTime + attackCooldown)
            {
                Attack();
            }
        }
        else if (isAttacking)
        {

        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        isDead = true;
        _rigidbody2D.velocity = Vector2.zero;
        _animator.SetTrigger("Death");
        Destroy(gameObject, 1f);
    }

    public void Attack()
    {
        if (!isDead)
        {
            isAttacking = true;
            _animator.SetTrigger("Attack");

            if (isStrong)
            {
                EnemyController enemy = FindObjectOfType<EnemyController>();
                enemy.TakeDamage(damage * 2);
            }

            else
            {
                EnemyController enemy = FindObjectOfType<EnemyController>();
                enemy.TakeDamage(damage);
            }
            lastAttackTime = Time.time;
        }
    }
}


