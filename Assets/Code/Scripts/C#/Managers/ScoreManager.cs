using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public event Action<int> ScoreChanged = delegate(int i) {  };
    public event Action<int> HighScoreChanged = delegate(int i) {  };
    
    public int Score { get; private set; }
    public int HighScore { get; private set; }

    private const string HighScoreKey = "High Score";
    
    public void ResetScore()
    {
        Score = 0;
        ScoreChanged(Score);
    }

    public void AddPoints(int points)
    {
        if (GameManager.Instance.GameState == GameState.GameOver) return;
        Score += points;
        ScoreChanged(Score);
        if (Score <= HighScore) return;
        HighScore = Score;
        HighScoreChanged(HighScore);
    }
    
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        HighScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        HighScoreChanged(HighScore);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt(HighScoreKey, HighScore);
    }
}