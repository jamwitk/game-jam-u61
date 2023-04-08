using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
using Player;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    private AudioSource _audio;
    public int damage;
    private void Awake()
    {
        _audio= GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.left * (Time.deltaTime * GameManager.Instance.obstacleSpeed));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //_audio.Play();
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
