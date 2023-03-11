
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool isPauseGame;
    public static GameManager instance { get; private set; }
    private void Start()
    {
        if (instance != null && instance != this) Destroy(this);
        else instance = this;
        isPauseGame = false;
    }
    public void StartGame()
    {

        SceneManager.LoadScene("Level 0");
    }
    public void SelectLevel()
    {
        SceneManager.LoadScene("LevelScene");
    }
    public void GameOver()
    {
        
        UIManager.instance.GameOverFame();
   
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPauseGame) {
                UIManager.instance.PlayerPause();
                isPauseGame = true;
            }
            else
            {
                UIManager.instance.Continue();
                isPauseGame = false;
            }
        }
       
    }
   public void CloseGame()
    {
        Application.Quit();
    }

}
