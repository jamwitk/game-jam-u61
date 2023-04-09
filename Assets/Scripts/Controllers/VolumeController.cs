using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    
    public AudioSource audioSource;
    public AudioSource audioSource2;
    [SerializeField] public Slider soundSlider;

    public void Start()
    {
        audioSource.Play();
        soundSlider.onValueChanged.AddListener(delegate { OnSoundLevelChanged(); });
    }

    public void OnSoundLevelChanged()
    {
        audioSource.volume = soundSlider.value;
        audioSource2.volume= soundSlider.value;
    }
}
