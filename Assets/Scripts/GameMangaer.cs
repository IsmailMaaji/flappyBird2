using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameMangaer : MonoBehaviour
{
    public static GameMangaer Instance;
    [SerializeField] private GameObject _gameOverCanvas;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        Time.timeScale = 1f;
        _gameOverCanvas.SetActive(false);
    }
   public void GameOver()
    {
        _gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        if (Score.instance != null)
        {
            Score.instance.ResetScore();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
