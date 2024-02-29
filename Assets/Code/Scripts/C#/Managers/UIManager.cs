using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    [SerializeField] TargetIndicator _targetIndicatorPrefab;
    [SerializeField] Canvas _mainCanvas;
    [SerializeField] TMP_Text _scoreText, _highScoreText;
    [SerializeField] private GameObject _gameOverScreen;
    List<TargetIndicator> _targetIndicators;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        _targetIndicators = new List<TargetIndicator>();
    }

    void OnEnable()
    {
        SubscribeToEvents();
        _gameOverScreen.SetActive(false);
    }

    void OnDisable()
    {
        UnsubscribeFromEvents();
    }

    void Start()
    {
        SubscribeToEvents();
    }

    public void AddTarget(Transform target)
    {
        var targetIndicator = Instantiate(_targetIndicatorPrefab, _mainCanvas.transform);
        targetIndicator.Init(target, _mainCanvas);
        _targetIndicators.Add(targetIndicator);
    }

    public void RemoveTarget(Transform target)
    {
        var key = target.GetInstanceID();
        var indicator = _targetIndicators.FirstOrDefault(i => i.Key == key);
        if (indicator)
        {
            _targetIndicators.Remove(indicator);
            Destroy(indicator.gameObject);
        }
    }

    public void UpdateTargetIndicators(List<Transform> targets, int lockedOnTarget)
    {
        foreach (var targetIndicator in _targetIndicators)
        {
            targetIndicator.gameObject.SetActive(targets.Any(target => target.GetInstanceID() == targetIndicator.Key));
            targetIndicator.LockedOn = targetIndicator.Key == lockedOnTarget;
        }
    }

    void SubscribeToEvents()
    {
        SubscribeToScoreManagerEvents();
        SubscribeToGameManagerEvents();
    }

    
    void UnsubscribeFromEvents()
    {
        UnsubscribeFromScoreManagerEvents();
        UnsubscribeToGameManagerEvents();
    }

    private void SubscribeToGameManagerEvents()
    {
        GameManager.Instance.GameStateChanged += OnGameStateChanged;
    }
    
    private void UnsubscribeToGameManagerEvents()
    {
        GameManager.Instance.GameStateChanged -= OnGameStateChanged;
    }
    

    void SubscribeToScoreManagerEvents()
    {
        if (!ScoreManager.Instance) return;
        UnsubscribeFromScoreManagerEvents();
        ScoreManager.Instance.ScoreChanged += OnScoreChanged;
        ScoreManager.Instance.HighScoreChanged += OnHighScoreChanged;
    }

    void UnsubscribeFromScoreManagerEvents()    
    {
        if (!ScoreManager.Instance) return;
        ScoreManager.Instance.ScoreChanged -= OnScoreChanged;
        ScoreManager.Instance.HighScoreChanged -= OnHighScoreChanged;    
    }
    
    private void OnGameStateChanged(GameState gameState)
    {
        _gameOverScreen.SetActive(gameState == GameState.GameOver);
    }

    void OnScoreChanged(int score)
    {
        _scoreText.text = score.ToString();
    }

    void OnHighScoreChanged(int highScore)
    {
        _highScoreText.text = highScore.ToString();
    }
}



