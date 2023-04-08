using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    
    Material mate;
    float distance;

    [Range(0f,0.5f)]
	public float speed = 0.2f;
    void Start()
    {
        mate = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        distance += Time.deltaTime *  speed;
		mate.SetTextureOffset("_MainTex", Vector2.right* distance);
    }
}
