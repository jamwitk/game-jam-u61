using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
using Player;
using UnityEngine;
using UnityEngine.UI;
public class Barrier : MonoBehaviour
{
    private AudioSource _audio;
    public int damage;
    public float fillPerReward = 5f;

    public float maxlive = 3f;
    public float live_subtract = 1f;
    private void Awake()
    {
        _audio= GetComponent<AudioSource>();
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            //_audio.Play();
            var pc = collision.gameObject.GetComponent<PlayerController>();
            pc.TakeDamage(damage);
            
            
            float liveAmount = pc.GetHealth() / (float) pc.maxHealth;
            GameObject.Find("Live").GetComponent<Image>().fillAmount = liveAmount;
            Destroy(gameObject);
        }
    }
}
