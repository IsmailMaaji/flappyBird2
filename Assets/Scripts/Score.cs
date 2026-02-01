using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance;
    [SerializeField] private TextMeshProUGUI _currentScoreText;
    [SerializeField] private TextMeshProUGUI _highScoreText;

    private int _score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _score = 0;
        Debug.Log("Score: Awake - instance initialized. Current score = " + _score);
    }

    private void Start()
    {
        if (_currentScoreText == null)
        {
            Debug.LogWarning("Score: _currentScoreText is not assigned in the inspector.");
        }

        if (_highScoreText == null)
        {
            Debug.LogWarning("Score: _highScoreText is not assigned in the inspector.");
        }

        if (_currentScoreText != null) _currentScoreText.text = _score.ToString();
        if (_highScoreText != null) _highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        Debug.Log("Score: Start - UI assigned? currentText=" + (_currentScoreText != null) + ", highText=" + (_highScoreText != null) + ", storedHigh=" + PlayerPrefs.GetInt("HighScore", 0));
        UpdateHighScore();
    }

    private void UpdateHighScore()
    {
        int stored = PlayerPrefs.GetInt("HighScore", 0);
        if (_score > stored)
        {
            PlayerPrefs.SetInt("HighScore", _score);
            PlayerPrefs.Save();
            if (_highScoreText != null) _highScoreText.text = _score.ToString();
        }
    }

    public void UpdateScore()
    {
        _score++;
        if (_currentScoreText != null) _currentScoreText.text = _score.ToString();
        UpdateHighScore();
    }

    // Reset current score to zero and update UI
    public void ResetScore()
    {
        _score = 0;
        if (_currentScoreText != null) _currentScoreText.text = _score.ToString();
    }

    // Backwards-compatible name and clearer API
    public void IncreaseScore()
    {
        Debug.Log("Score: IncreaseScore called. Previous score=" + _score);
        UpdateScore();
        Debug.Log("Score: Increased. New score=" + _score);
    }
}

