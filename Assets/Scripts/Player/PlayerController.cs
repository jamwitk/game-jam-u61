using System;
using Controllers;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private int health = 3;
        public int maxHealth = 3;
        private void Start()
        {
            
        }
        public int GetHealth()
        {
            return health;
        }
        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            // play death animation if is grounded
            // if not grounded, play death animation and fall
            // destroy game object
            GameManager.Instance.PlayerDead();
        }
    }
}
