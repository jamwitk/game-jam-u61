using Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Award : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource _audio;
    public float fillPerReward = 4f;
    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }
 
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Award"))
        {
            _audio.Play();
            GameObject.Find("Bar").GetComponent<Image>().fillAmount = Amount.fillAmount;
            Amount.fillAmount += fillPerReward / 60f;
            Amount.fillAmount = Mathf.Clamp01(Amount.fillAmount);
            Destroy(collision.gameObject);

        }
    }
}
