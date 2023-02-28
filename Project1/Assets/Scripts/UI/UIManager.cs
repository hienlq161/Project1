
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
  //  [SerializeField] private GameObject gameOverScreen;
   // [SerializeField] private AudioClip gameOverSound;
         GameObject pauseGameScreen;
    public static UIManager instance { get; private set; }
    private void Awake()
    {
        instance = this;
    }
    
   
    private void Start()
    {
        pauseGameScreen = GameObject.FindGameObjectWithTag("UIInLevel");
        pauseGameScreen.SetActive(false);

    }
    public void GameOverFame()
    {
        pauseGameScreen.SetActive(true);
        Time.timeScale = 0;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
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
