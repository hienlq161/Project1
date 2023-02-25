
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
  //  [SerializeField] private GameObject gameOverScreen;
   // [SerializeField] private AudioClip gameOverSound;
        private GameObject pauseGameScreen;
 
    public void GameOver()
    {
    //   gameOverScreen.SetActive(true);

    }
   
    private void Start()
    {
        pauseGameScreen = GameObject.FindGameObjectWithTag("UIInLevel");
        pauseGameScreen.SetActive(false);

    }
    public void PlayerPause()
    {
        SoundManager.Instance.OnPauseState();
        pauseGameScreen.SetActive(true);
        Time.timeScale  = 0;
     
    }
    public void Continue()
    {
        pauseGameScreen.SetActive(false);
        SoundManager.Instance.OnCountinueState();
        Time.timeScale = 1;
    }
   
}
