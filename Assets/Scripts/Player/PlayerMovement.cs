using System;
using Controllers;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public int jumpForce;
        public int speed;
        private Rigidbody2D _rb;
        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        
        private void FixedUpdate()
        {
            if(GameManager.Instance.IsGameOver) return;
            if (Input.touchCount > 0 || Input.GetMouseButton(0) && transform.position.y < 4f)
            {
                _rb.AddForce(Vector2.up * jumpForce);
                //_rb.AddForce(Vector2.right * jumpForce); -- parallax kontrolünü denemek için bu yorum satırını açıp, yukarıdaki satırı yorum satırına alabilirsiniz.
            }
            _rb.velocity = new Vector2(speed, _rb.velocity.y);
        }
    }
}