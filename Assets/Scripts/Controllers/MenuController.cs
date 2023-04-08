using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controllers
{
    public class MenuController : MonoBehaviour
    {
        public GameObject optionsPanel;
        public void OnClickStartButton()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        public void OnClickOptionsButton()
        {
            optionsPanel.SetActive(true);
        }
        public void OnClickCloseOptionsButton()
        {
            optionsPanel.SetActive(false);
        }
        public void OnClickExitButton()
        {
            Application.Quit();
        }
    }
}
