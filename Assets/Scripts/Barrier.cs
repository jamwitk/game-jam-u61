using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource _audio;
    private void Awake()
    {
        _audio= GetComponent<AudioSource>();
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            _audio.Play();
        }
    }*/
}
