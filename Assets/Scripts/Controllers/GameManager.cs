using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controllers
{
    public class GameManager : Singleton<GameManager>
    {
        public GameObject DeathScreen;
        public bool IsGameOver { get; private set; }
        public delegate void OnPlayerDead();
        public event OnPlayerDead PlayerDeadEvent;
        
        public void PlayerDead()
        {
            IsGameOver = true;
            PlayerDeadEvent?.Invoke();
            Invoke(nameof(ShowDeathScreen), 0.6f);
        }
        public void ShowDeathScreen()
        {
            DeathScreen.SetActive(true);
        }
        public void RestartGame()
        {
            //any game state to prepare for restart
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            IsGameOver = false;
        }
        
    }
}