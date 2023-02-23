
using UnityEngine;

public class UIManager : MonoBehaviour
{
  //  [SerializeField] private GameObject gameOverScreen;
   // [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private GameObject pauseGameScreen;

    public void GameOver()
    {
    //   gameOverScreen.SetActive(true);

    }
    private void Awake()
    {
        pauseGameScreen.SetActive(false);

    }
    public void PlayerPause()
    {
        SoundManager.Instance.OnPauseState();
        pauseGameScreen.SetActive(true);
        pauseGameScreen.SetActive(true);
    }
    public void Continue()
    {
        pauseGameScreen.SetActive(false);
        SoundManager.Instance.OnCountinueState();
        pauseGameScreen.SetActive(false) ;
    }
}
