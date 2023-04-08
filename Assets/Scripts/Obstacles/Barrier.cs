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
        GameObject.Find("Bar").GetComponent<Image>().fillAmount = Amount.fillAmount;
        
        if (collision.gameObject.CompareTag("Player"))
        {
            //_audio.Play();
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
            Destroy(gameObject);
            Amount.fillAmount += fillPerReward/60f;
            Amount.fillAmount = Mathf.Clamp01(Amount.fillAmount);

            GameObject.Find("Live").GetComponent<Image>().fillAmount = Amount.total_live;
            Amount.total_live -= live_subtract / 3f;
            Amount.total_live = Mathf.Clamp01(Amount.total_live);
        }
    }
}
