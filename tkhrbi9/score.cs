using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class score : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI HighscoreText;
    
    private int current_score = 0;

    public static score instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        if (scoreText != null)
        {
            scoreText.text = current_score.ToString();
        }
        else
        {
            Debug.LogError("scoreText is not assigned in the Inspector!");
        }

        if (HighscoreText != null)
        {
            HighscoreText.text = PlayerPrefs.GetInt("high_score", 0).ToString();
        }
        else
        {
            Debug.LogError("HighscoreText is not assigned in the Inspector!");
        }

        updateHighscore();
    }

    public void increaseScore()
    {
        current_score++;
        if (scoreText != null)
        {
            scoreText.text = current_score.ToString();
        }
        updateHighscore();
    }

    private void updateHighscore()
    {
        int highscore = PlayerPrefs.GetInt("high_score", 0);
        if (current_score > highscore)
        {
            PlayerPrefs.SetInt("high_score", current_score);
            if (HighscoreText != null)
            {
                HighscoreText.text = current_score.ToString();
            }
        }
    }
}
