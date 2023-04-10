using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Books : MonoBehaviour
{
    // Start is called before the first frame update
    //public int score = 0;
    //private AudioSource _audio;
    /*private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }*/
    private void OnCollisionEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            Destroy(collision.gameObject);
            //score++;
            //_audio.Play();
        }
    }
   
}
