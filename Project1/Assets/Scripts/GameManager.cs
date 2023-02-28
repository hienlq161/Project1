using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject UiLevel;
    bool isPauseGame;
    public static GameManager instance { get; private set; }
    private void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        isPauseGame = false;
    }
    public void StartGame()
    {

        SceneManager.LoadScene("Level0");
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
                UiLevel.GetComponent<UIManager>().PlayerPause();
                isPauseGame = true;
            }
            else
            {
                UiLevel.GetComponent<UIManager>().Continue();
                isPauseGame = false;
            }
        }
       
    }

}
