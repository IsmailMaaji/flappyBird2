using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void PlayFlappyBird()
    {
        SceneManager.LoadScene("flappy_bird");
    }

    public void PlayBouncyBall()
    {
        SceneManager.LoadScene("bouncy_ball");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
