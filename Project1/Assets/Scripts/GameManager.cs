using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject UiLevel;
    bool isPauseGame;
    private void Awake()
    {
        UiLevel = GameObject.FindGameObjectWithTag("UIInLevel");
        DontDestroyOnLoad(gameObject);
        isPauseGame = false;
    }
    public void StartGame()
    {

        SceneManager.LoadScene("Level0");
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
