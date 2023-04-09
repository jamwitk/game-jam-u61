using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail_dead : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private bool touched = false;
    private SpriteRenderer spriteRenderer;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("IsDeath", true);
            Invoke(nameof(DestroyAfter),0.6f);
        }
    }

    public void DestroyAfter()
    {
        Destroy(gameObject);
    }
}
