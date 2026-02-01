using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private AudioClip gameOverSound;
    private AudioSource audioSource;
    public bool isGameOver { get; private set; } = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
        
        audioSource = gameObject.AddComponent<AudioSource>();
        Time.timeScale = 1f;
    }
    public void GameOver() 
    {
        isGameOver = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
        
        if (gameOverSound != null && audioSource != null)
        {
            audioSource.clip = gameOverSound;
            audioSource.time = 1f; // Start at 2 seconds
            audioSource.Play();
        }
    }


    public void RestartGame()
    {isGameOver = false;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
