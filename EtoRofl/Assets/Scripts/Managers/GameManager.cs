using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject winScreen;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.onCollidedWithPlayer += OnGameOver;
        EventManager.onWonTheGame += OnWonTheGame;
    }

    private void OnGameOver()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true); 
        }
        Time.timeScale = 0;
    }

    private void OnWonTheGame()
    {
        if (winScreen != null)
        {
            winScreen.SetActive(true);
        }
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        EventManager.onCollidedWithPlayer -= OnGameOver;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayTheGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameLevel");
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void TestDebug()
    {
        Debug.Log("Test");
    }
}
