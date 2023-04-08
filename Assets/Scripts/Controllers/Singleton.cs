using System;
using UnityEngine;

namespace Controllers
{
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        public static T Instance { get; set; }
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this as T;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}