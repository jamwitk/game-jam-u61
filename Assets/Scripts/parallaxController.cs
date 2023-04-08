using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxController : MonoBehaviour
{
     Transform cam;
     private Vector3 camStartPos;
     private float distance;

     private GameObject[] backgrounds
         ;
     private Material[] mate;
     private float[] backSpeed;

     private float farhestBack;

     [Range(0.01f, 0.05f)] public float parallaxSpeed;
     void Start()
     {
         cam = Camera.main.transform;
         camStartPos = cam.position;

         int backCount = transform.childCount;
         mate = new Material[backCount];
         backSpeed = new float[backCount];
         backgrounds = new GameObject[backCount];

         for (int i = 0; i < backCount; i++)
         {
             backgrounds[i] = transform.GetChild(i).gameObject;
             mate[i] = backgrounds[i].GetComponent<Renderer>().material;
         }
         

     }

     void BackSpeedCalculate(int backCount)
     {
         for (int i = 0; i < backCount; i++)
         {
             if ((backgrounds[i].transform.position.z - cam.position.z) > farhestBack)
             {
                 farhestBack = backgrounds[i].transform.position.z - cam.position.z;
             }
                 
         }

         for (int i = 0; i < backCount; i++)
         {
             backSpeed[i] = 1 - (backgrounds[i].transform.position.z - cam.position.z) / farhestBack;
         }
     }

     private void LateUpdate()

     {
         distance = cam.position.x - camStartPos.x;
         for (int i = 0; i < backgrounds.Length; i++)
         {
             float speed = backSpeed[i] * parallaxSpeed;
             mate[i].SetTextureOffset("_MainTex",new Vector2(distance,0)*speed);
         }
     }
}
