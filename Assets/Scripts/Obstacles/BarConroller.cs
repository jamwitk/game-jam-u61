using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarConroller : MonoBehaviour
{
    public float maxTime = 60f; 
    public float fillPerSecond = 1f; 
    
    void Update()
    {
        GameObject.Find("Bar").GetComponent<Image>().fillAmount = Amount.fillAmount;
        float deltaTime = Time.deltaTime; 
        Amount.fillAmount += (deltaTime / maxTime) * fillPerSecond; 
        Amount.fillAmount = Mathf.Clamp01(Amount.fillAmount); 

        
    }
}
